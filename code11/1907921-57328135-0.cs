    private async Task UploadToAzureBlobStorage(string schedule, string path, string fileName) {
    	try {
    		if (CloudStorageAccount.TryParse(StorageConnectionString, out CloudStorageAccount cloudStorageAccount)) {
    			var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
    			var cloudBlobContainer = cloudBlobClient.GetContainerReference(schedule);
    			var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
    			await cloudBlockBlob.UploadFromFileAsync(path);
    		}
    		else {
    			throw new CustomConfigurationException(CustomConstants.NoStorageConnectionStringSettings);
    		}
    	}
    	catch(Exception ex) {
    		throw new CustomConfigurationException($ "Error when uploading to blob: {ex.Message}");
    	}
    }
