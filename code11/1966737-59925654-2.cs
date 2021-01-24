        var containerName = "<container name>";
        var accountName = "<storage account name>";
        var key = "<storage account key>";
        var cred = new StorageCredentials(accountName, key);
        var account = new CloudStorageAccount(cred,true);
        var container = account.CreateCloudBlobClient().GetContainerReference(containerName);
        var writeOnlyPolicy = new SharedAccessBlobPolicy() { 
            SharedAccessStartTime = DateTime.Now,
            SharedAccessExpiryTime = DateTime.Now.AddHours(2),
            Permissions = SharedAccessBlobPermissions.Write
        };
        var sas = container.GetSharedAccessSignature(writeOnlyPolicy);
