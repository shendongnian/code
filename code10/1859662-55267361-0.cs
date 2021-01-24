      string storageUrl = "https://[your account here].blob.core.windows.net";
      string sasToken = "?sv=20XX-XX-XX&ss=x&srt=xxx&sp=xxxx&...";
      string containerName = "data-protection-XXXX-XXXX-container";
      string blobName = "data-protection-XXXX-XXXX-blob";
    
       // Create the new Storage URI
       Uri storageUri = new Uri($"{storageUrl}{sasToken}");
    
       //Create the blob client object.
       CloudBlobClient blobClient = new CloudBlobClient(storageUri);
    
       //Get a reference to a container. Create it if it does not exist.
       CloudBlobContainer container = blobClient.GetContainerReference(containerName);
    
       // (NOTE: internal library, do not use in your code)
       AsyncHelper.Guarded<bool>(() => { return container.CreateIfNotExistsAsync();  });
                    
    
       services.AddDataProtection()
    		.SetApplicationName("[your application name here]")
            .PersistKeysToAzureBlobStorage(container, blobName)
            .SetDefaultKeyLifetime(new TimeSpan(365 * 10, 0, 0, 0, 0));
