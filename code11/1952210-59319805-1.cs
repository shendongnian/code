    public async Task PostWebApi(string webApiUrl, string accessToken, IFormFile fileToUpload)
        {
            
            //Create a Stream and convert it to a required HttpContent-stream (StreamContent).
            // Important is the using{...}. This keeps the stream open until processed
            using (MemoryStream data = new MemoryStream())
            {
                await fileToUpload.CopyToAsync(data);
                data.Seek(0, SeekOrigin.Begin);
                var buf = new byte[data.Length];
                data.Read(buf, 0, buf.Length);
                data.Position = 0;
                HttpContent content = new StreamContent(data);
                
                if (!string.IsNullOrEmpty(accessToken))
                {
                    // NO Headers other than the AccessToken should be added. If you do
                    // an Error 406 is returned (cannot process). So, no Content-Types, no Conentent-Dispositions
                    var defaultRequestHeaders = HttpClient.DefaultRequestHeaders;                    
                    defaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
                    HttpResponseMessage response = await HttpClient.PutAsync(webApiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return;
                    }
                    else
                    {
                        // do something else
                        return;
                    }
                }
                content.Dispose();
                data.Dispose();
            } //einde using memorystream 
        }
    }
