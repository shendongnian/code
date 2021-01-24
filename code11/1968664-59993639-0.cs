    private static string GetBlobSasUri(CloudBlobContainer container, string blobName, string policyName = null)
    {
        string sasBlobToken;
    
        // Get a reference to a blob within the container.
        // Note that the blob may not exist yet, but a SAS can still be created for it.
        CloudBlockBlob blob = container.GetBlockBlobReference(blobName);
    
        if (policyName == null)
        {
            // Create a new access policy and define its constraints.
            // Note that the SharedAccessBlobPolicy class is used both to define the parameters of an ad hoc SAS, and
            // to construct a shared access policy that is saved to the container's shared access policies.
            SharedAccessBlobPolicy adHocSAS = new SharedAccessBlobPolicy()
            {
                // When the start time for the SAS is omitted, the start time is assumed to be the time when the storage service receives the request.
                // Omitting the start time for a SAS that is effective immediately helps to avoid clock skew.
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Create
            };
    
            // Generate the shared access signature on the blob, setting the constraints directly on the signature.
            sasBlobToken = blob.GetSharedAccessSignature(adHocSAS);
    
            Console.WriteLine("SAS for blob (ad hoc): {0}", sasBlobToken);
            Console.WriteLine();
        }
        else
        {
            // Generate the shared access signature on the blob. In this case, all of the constraints for the
            // shared access signature are specified on the container's stored access policy.
            sasBlobToken = blob.GetSharedAccessSignature(null, policyName);
    
            Console.WriteLine("SAS for blob (stored access policy): {0}", sasBlobToken);
            Console.WriteLine();
        }
    
        // Return the URI string for the container, including the SAS token.
        return blob.Uri + sasBlobToken;
    }
