     public List<string> GetAllBlobUrisInContainer(string containerName, string blobNamePrefix = "")
        {
            List<string> uriList = new List<string>();
            var container = GetBlobContainer(containerName);
            var blobList = container.ListBlobs(useFlatBlobListing: true);
            foreach (var cloudBlockBlob in blobList)
            {
                uriList.Add(cloudBlockBlob.Uri.ToString());
            }
            return uriList;
        }
