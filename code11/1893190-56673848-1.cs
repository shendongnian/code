     public List<string> GetBlobUris(string containerName, string directoryPath = "")
            {
                List<string> uriList = new List<string>();
                List<CloudBlockBlob> cloudBlockBlobs = GetBlobs(containerName, directoryPath);
                foreach (var cloudBlockBlob in cloudBlockBlobs)
                {
                    uriList.Add(cloudBlockBlob.Uri.ToString());
                }
                return uriList;
            }
    
    
            public List<CloudBlockBlob> GetBlobs(string containerName, string directoryPath = "")
            {
                List<CloudBlockBlob> response;
    
                var container = GetBlobContainer(containerName);
    
                if (string.IsNullOrEmpty(directoryPath))
                {
                    response = container.ListBlobs().OfType<CloudBlockBlob>().ToList();
                }
                else
                {
                    var dirRef = container.GetDirectoryReference(directoryPath);
                    response = dirRef.ListBlobs().OfType<CloudBlockBlob>().ToList();
                }
    
                return response;
            }
