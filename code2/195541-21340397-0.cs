    public static class BlobContainerExtensions 
    {
        public static void Rename(this CloudBlobContainer container, string oldName, string newName)
        {
            var source = container.GetBlobReferenceFromServer(oldName);
            var target = container.GetBlockBlobReference(newName);
            target.StartCopyFromBlob(source.Uri);
            source.Delete();
        }
        public static async Task RenameAsync(this CloudBlobContainer container, string oldName, string newName)
        {
            var source = await container.GetBlobReferenceFromServerAsync(oldName);
            var target = container.GetBlockBlobReference(newName);
            await target.StartCopyFromBlobAsync(source.Uri);
            await source.DeleteAsync();
        }
    }
