csharp
        public async Task<string> PostFile(string url, string filepath)
        {
            var request = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(3600)
            };
            var form = new MultipartFormDataContent();
            string responseString = null;
            using (var fileStream = new FileStream(filepath, mode: FileMode.Open))
            {
                using (var bufferedStream = new BufferedStream(fileStream))
                {
                    form.Add(new StreamContent(bufferedStream), "file", new FileInfo(filepath).FullName);
                    var response = await request.PostAsync(url, form);
                    responseString = await response.Content.ReadAsStringAsync();
                    fileStream.Close();
                }
            }
            return responseString;
        }
And the problem solved.
