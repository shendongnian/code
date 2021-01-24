     public List<string> GetContainerUris(string containerName)
            {
                try
                {
                    return GetAllContainerUris(containerName);
                }
                catch(Exception e)
                {
                    return new List<string>();
                }
            }
    
    
            private List<string> GetAllContainerUris(string containerName)
            {
            var containerUris = new List<string>();
            containerUris.AddRange(GetBlobUris(containerName));
            var directories = GetAllDirectoriesInContainer(containerName);
            foreach(var dir in directories)
            {
                containerUris.AddRange(GetBlobUris(containerName, dir.Prefix));
            }
            return containerUris;
        }
