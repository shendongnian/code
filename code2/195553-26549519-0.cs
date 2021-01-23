    public void Rename(string containerName, string oldFilename, string newFilename)
    {
        var oldBlob = GetBlobReference(containerName, oldFilename);
        var newBlob = GetBlobReference(containerName, newFilename);
            
        using (var stream = new MemoryStream())
        {
            oldBlob.DownloadToStream(stream);
            stream.Seek(0, SeekOrigin.Begin);
            newBlob.UploadFromStream(stream);
            //copy metadata here if you need it too
            oldBlob.Delete();
        }
    }
