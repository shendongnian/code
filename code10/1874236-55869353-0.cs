    //This is the collection containing your descriptions
    public ObservableCollection<string> Blobs = new ObservableCollection<string>();
    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        const string StorrageAccountName = "****";
        const string StorageAccountKey = "*****==";
        var storageAccount = new CloudStorageAccount(
            new Microsoft.Azure.Storage.Auth.StorageCredentials(StorrageAccountName, StorageAccountKey), true);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference("***");
        var description = string.Empty;
        foreach (IListBlobItem item in container.ListBlobs(null, false))
        {
            if (item.GetType() == typeof(CloudBlockBlob))
            {
                CloudBlockBlob blob = (CloudBlockBlob)item;
                description = $"Block blob of length {blob.Properties.Length}: {blob.Uri}";
            }
            else if (item.GetType() == typeof(CloudPageBlob))
            {
                CloudPageBlob pageBlob = (CloudPageBlob)item;
                description = $"Page blob of length {pageBlob.Properties.Length}: {pageBlob.Uri}";
            }
            else if (item.GetType() == typeof(CloudBlobDirectory))
            {
                CloudBlobDirectory directory = (CloudBlobDirectory)item;
                description = $"Directory: {directory.Uri}";
            }
            // add your descriptions to the collection
            Blobs.Add(description);
        }
    }
