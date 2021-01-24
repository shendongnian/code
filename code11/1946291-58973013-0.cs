     public async Task<HttpResponseMessage> PostMultipart(string apiendpoint, byte[] data)
            {
    
                var multipartContent = new MultipartFormDataContent(); // your boundary value if need anything can be passed in the contructore
                var fileContent = new ByteArrayContent(data);
                fileContent.Headers.ContentType =
                    MediaTypeHeaderValue.Parse("image/jpeg");
    
                multipartContent.Add(fileContent, "file", "filename.jpg");
                //client is HttpClient static field in the class
                return await client.PostAsync(apiendpoint, multipartContent);
            }
