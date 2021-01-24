            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = blobContainerName,
                BlobName = blobName,
                Resource = "b", //b = blob, c = container
                StartsOn = DateTimeOffset.UtcNow,
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(lifetimeMinutes)
            };
            blobSasBuilder.SetPermissions(BlobSasPermissions.Read);
            StorageSharedKeyCredential storageSharedKeyCredential = new StorageSharedKeyCredential(accountName, accountKey);
            string sas = blobSasBuilder.ToSasQueryParameters(storageSharedKeyCredential).ToString();
