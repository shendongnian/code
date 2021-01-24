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
                    requestMessage.Headers.Add("ContentType", "application/x-www-form-urlencoded");
                    requestMessage.Content = content;
                    var response = await httpClient.SendAsync(requestMessage);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    var vimeoTicket = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                    vimeoUploadUrl = vimeoTicket.SelectToken("upload.upload_link").ToString();
                    var videoLinkForUseAfterUploading = vimeoTicket.GetValue("link").ToString();
                    Console.WriteLine("videoLinkForUseAfterUploading: " + videoLinkForUseAfterUploading);
                    string videoNumber = videoLinkForUseAfterUploading.Substring(videoLinkForUseAfterUploading.LastIndexOf("/") + 1);
                    Console.WriteLine("videoNumber: " + videoNumber);
                }
            }
            catch (Exception err)
            {
                var errMessage = err.Message;               
                Console.WriteLine("In getVimeoUploadUrl() error: " + err.Message);
            }
            return vimeoUploadUrl;
        }
