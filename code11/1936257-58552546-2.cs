        HttpClient httpClient = new HttpClient();
        public async Task<string> getVimeoUploadUrl(int videoFileSize, string accessToken)
        {
            var vimeoUploadUrl = "";
            string vimeoApiUrl = "https://api.vimeo.com/me/videos"; // Vimeo URL
            try
            {
                string body =
                    @"{'upload': {'approach': 'post','size': '" + videoFileSize + "'}}".Replace("'", "\"");
                HttpContent content = new StringContent(body);
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, vimeoApiUrl))
                {
                    requestMessage.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", accessToken);
                    requestMessage.Headers.Add("Accept", "application/vnd.vimeo.*+json;version=3.4");
                    requestMessage.Headers.Add("ContentType", "application/json");
                    requestMessage.Content = content;
                    var response = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var myJsonObject = JObject.Parse(result);
                    vimeoUploadUrl = myJsonObject.SelectToken("upload.upload_link").ToString();                  
                }
            }
            catch (Exception err)
            {
            // Do your own error handling!   
            }
            return vimeoUploadUrl;
        }
