        public static async Task RenameAsync(this CloudBlobContainer container, string oldName, string newName)
        {
            CloudBlockBlob source =(CloudBlockBlob)await container.GetBlobReferenceFromServerAsync(oldName);
            CloudBlockBlob target = container.GetBlockBlobReference(newName);
            
            await target.StartCopyAsync(source);
            
            while (target.CopyState.Status == CopyStatus.Pending)
                await Task.Delay(100);
            if (target.CopyState.Status != CopyStatus.Success)
                throw new ApplicationException("Rename failed: " + target.CopyState.Status);
            await source.DeleteAsync();            
        }
