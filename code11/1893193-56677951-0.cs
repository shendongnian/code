    public List<string> GetBlobUris(string containerName, string blobNamePrefix = "")
    {
        List<string> uriList = new List<string>();
        var container = GetBlobContainer(containerName);
        List<CloudBlockBlob> cloudBlockBlobs = GetBlobs(containerName, directoryPath);
        foreach (var cloudBlockBlob in cloudBlockBlobs)
        {
            uriList.Add(cloudBlockBlob.Uri.ToString());
        }
        return uriList;
    }
    public List<CloudBlockBlob> GetBlobs(string containerName, string blobNamePrefix = "")
    {
        var container = GetBlobContainer(containerName);
        return container.ListBlobs().OfType<CloudBlockBlob>().Where(b => b.Name.StartsWith(blobNamePrefix)).ToList();
    }
