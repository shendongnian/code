    const string url = "https://localhost:5001/api/Upload";
    const string filePath = @"C:\Path\To\File.png";
    
    using (var httpClient = new HttpClient())
    {
        using (var form = new MultipartFormDataContent())
        {
            using (var fs = File.OpenRead(filePath))
            {
                using (var streamContent = new StreamContent(fs))
                {
                    using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                    {
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
    
    					// "file" parameter name should be the same as the server side input parameter name
                        form.Add(fileContent, "file", Path.GetFileName(filePath));
                        HttpResponseMessage response = await httpClient.PostAsync(url, form);
                    }
                }
            }
        }
    }
