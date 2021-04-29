using System;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace SharedKeyPerBlobSAS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Allow to generate a temporary sharedKey per blob (file) valid for N time.

            string connectionString = "";
            string containerName = "";
            string blobName = "";

            // Get a reference to a container
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            // Get a reference to a blob in a container
            BlobClient blob = container.GetBlobClient(blobName);

            // Get a user delegation key for the Blob service that's valid for N time.
            // You can use the key to generate any number of shared access signatures 
            // over the lifetime of the key.

            Console.WriteLine("Hour generated: {0}", DateTimeOffset.UtcNow);
            Console.WriteLine();

            Console.WriteLine("Hour expires: {0}", DateTimeOffset.UtcNow.AddSeconds(30));
            Console.WriteLine();

            var blobSasUri = blob.GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddSeconds(30));

            Console.WriteLine("Blob user delegation SAS URI: {0}", blobSasUri.AbsoluteUri);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
