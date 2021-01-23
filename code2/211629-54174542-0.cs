    static class WebClientExtensions
    {
        public static async Task<string> DownloadFileToDirectory(this WebClient client, string address, string directory, string defaultFileName)
        {
            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException("Downloads directory must exist");
            string filePath = null;
            using (var stream = await client.OpenReadTaskAsync(address))
            {
                var fileName = TryGetFileNameFromHeaders(client);
                if (string.IsNullOrWhiteSpace(fileName))
                    fileName = defaultFileName;
                filePath = Path.Combine(directory, fileName);
                await WriteStreamToFile(stream, filePath);
            }
            return filePath;
        }
        private static string TryGetFileNameFromHeaders(WebClient client)
        {
            // content-disposition might contain the suggested file name, typically same as origiinal name on the server
            // Originally content-disposition is for email attachments, but web servers also use it.
            string contentDisposition = client.ResponseHeaders["content-disposition"];
            return string.IsNullOrWhiteSpace(contentDisposition) ?
                null :
                new ContentDisposition(contentDisposition).FileName;
        }
        private static async Task WriteStreamToFile(Stream stream, string filePath)
        {
            // Code below will throw generously, e. g. when we don't have write access, or run out of disk space
            using (var outStream = new FileStream(filePath, FileMode.CreateNew))
            {
                var buffer = new byte[8192];
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    // Could use async variant here as well. Probably helpful when downloading to a slow network share or tape. Not my use case.
                    outStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
