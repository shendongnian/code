    public async Task<HttpResponseMessage> DownloadBlobAsync(string file, string fileExtension, string directory)
    {
        _container = _client.GetContainerReference(containerName);
        _directoy = _container.GetDirectoryReference(directory);
        CloudBlockBlob blockBlob = _directoy.GetBlockBlobReference(file + "." + fileExtension);
        using (var ms = new MemoryStream())
        {
            await blockBlob.DownloadToStreamAsync(ms);
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(ms.ToArray())
            };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "somefilename.ext"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(blockBlob.Properties.ContentType);
            return result;
        }
    }
