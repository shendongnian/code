        void Upload()
        {
            var content = new MultipartFormDataContent();
            // Add the file
            var fileContent = new ByteArrayContent(file);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    FileName = fileName,
                    FileNameStar = "file"
                };
    content.Add(fileContent);
                //this is the way to add more content to the post
                content.Add(new StringContent(documentUploadDto.DocumentName), "DocumentName");
                var url = "myapi.com/api/documents";
                HttpResponseMessage response = null;
                try
                {
                    response = await _httpClient.PostAsync(url, content);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
        }
