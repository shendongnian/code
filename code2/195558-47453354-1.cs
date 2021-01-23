     public async Task<CloudBlockBlob> RenameAsync(CloudBlockBlob srcBlob, CloudBlobContainer destContainer,string name)
        {
            CloudBlockBlob destBlob;
            if (srcBlob == null && srcBlob.Exists())
            {
                throw new Exception("Source blob cannot be null and should exist.");
            }
            if (!destContainer.Exists())
            {
                throw new Exception("Destination container does not exist.");
            }
            //Copy source blob to destination container            
            destBlob = destContainer.GetBlockBlobReference(name);
            await destBlob.StartCopyAsync(srcBlob);
            //remove source blob after copy is done.
            srcBlob.Delete();
            return destBlob;
        }
