        public async Task<string> AttachFile(string file, string fileName, string id)
        {
            var decoded = Convert.FromBase64String(file);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + ApiKey);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "multipart/form-data");
            MultipartFormDataContent form = new MultipartFormDataContent();
            var fileCont = new ByteArrayContent(decoded, 0, decoded.Length);
            fileCont.Headers.Add("Content-Disposition", $"form-data; name=\"file\"; filename=\"{fileName}\"");
            form.Add(fileCont);
            HttpResponseMessage response = await httpClient.PostAsync($@"https://app.asana.com/api/1.0/tasks/{id}/attachments", form);
            var responseData = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return "file was uploaded successfully";
            throw new ArgumentException($"Error code: {response.StatusCode}; {responseData}");
        }
