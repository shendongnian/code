    static async Task<bool> UploadFilesAsync(params string[] paths)
    {
        HttpClient client = new HttpClient();
        // we need to send a request with multipart/form-data
        var multiForm = new MultipartFormDataContent();
        foreach (string path in paths)
        {
            // add file and directly upload it
            FileStream fs = File.OpenRead(path);
            var streamContent = new StreamContent(fs);
            //string dd = MimeType(path);
            var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync());
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            multiForm.Add(fileContent, "files", Path.GetFileName(path));
        }
        // send request to API
        var url = "http://localhost:5000/api/values/upload";
        using (var response = await client.PostAsync(url, multiForm))
        {
            return response.IsSuccessStatusCode;
        }
    }
