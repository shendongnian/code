    private async Task<string> SendUploadImagesAsync(PhotoSceneImages obj, HttpMethod method, string token)
    {
        const string url = "https://developer.api.autodesk.com/photo-to-3d/v1/file";
        
        using (var client = new HttpClient())
        {
            var formData = new MultipartFormDataContent
            {
                {new StringContent(obj.photosceneid), "photosceneid"}, {new StringContent(obj.type), "type"}
            };
            var i = 0;
            foreach (var file in obj.files)
            {
                formData.Add(new ByteArrayContent(file.byteArray), $"file[{i++}]", file.filename);
            }
            var request = new HttpRequestMessage
            {
                Content = formData,
                Headers =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", token)
                },
                Method = method,
                RequestUri = new Uri(url)
            };
            Debug.Log($"request: {request}");
            try
            {
                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
