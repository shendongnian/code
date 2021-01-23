        public CloudBlockBlob RenameBlob(string oldName, string newName, CloudBlobContainer container)
        {
            if (!container.Exists())
            {
                throw new Exception("Destination container does not exist.");
            }
            //Get blob reference
            CloudBlockBlob sourceBlob = container.GetBlockBlobReference(oldName);
            if (sourceBlob == null && sourceBlob.Exists())
            {
                throw new Exception("Source blob cannot be null and should exist.");
            }
            // Get blob reference to which the new blob must be copied
            CloudBlockBlob destBlob = container.GetBlockBlobReference(newName);
            destBlob.StartCopyAsync(sourceBlob);
            //Delete source blob
            sourceBlob.Delete();
            return destBlob;
        }
