    private void UploadFile(string bucketName, string localPath,
        string objectName = null)
    {
        var storage = StorageClient.Create();
        using (var f = File.OpenRead(localPath))
        {
            objectName = objectName ?? Path.GetFileName(localPath);
            storage.UploadObject(bucketName, objectName, null, f);
            Console.WriteLine($"Uploaded {objectName}.");
        }
    }
