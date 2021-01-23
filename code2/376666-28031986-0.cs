    public async Task<HttpResponseMessage> UploadFileAsync( string uploadUrl, string absoluteFilePath, Action<int> progressPercentCallback )
        {
            var length = new FileInfo( absoluteFilePath ).Length;
            var request = new HttpWebRequest( new Uri(uploadUrl) ) {
                Method = "PUT",
                AllowWriteStreamBuffering = false,
                AllowReadStreamBuffering = false,
                ContentLength = length
            };
            const int chunkSize = 4096;
            var buffer = new byte[chunkSize];
            using (var req = await request.GetRequestStreamAsync())
            using (var readStream = File.OpenRead(absoluteFilePath))
            {
                progressPercentCallback(0);
                int read = 0;
                for (int i = 0; i < length; i += read)
                {
                    read = await readStream.ReadAsync( buffer, 0, chunkSize );
                    await req.WriteAsync( buffer, 0, read );
                    await req.FlushAsync(); // flushing is required or else we jump to 100% very fast
                    progressPercentCallback((int)(100.0 * i / length));
                }
                progressPercentCallback(100);
            }
            var response = (HttpWebResponse)await request.GetResponseAsync();
            var result = new HttpResponseMessage( response.StatusCode );
            result.Content = new StreamContent( response.GetResponseStream() );
            return result; 
        }
