    HttpClient httpClient = new HttpClient();
    
        public async Task deleteVideo(string videoNumber, string accessToken) 
        {
            try
            {
                string vimeoApiUrl = "https://api.vimeo.com/videos/" + videoNumber; // Vimeo URL
                var body = "{}";
                HttpContent content = new StringContent(body);
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Delete, vimeoApiUrl))
                {
                    requestMessage.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", accessToken);
                    requestMessage.Headers.Add("Accept", "application/vnd.vimeo.*+json;version=3.4");
                    requestMessage.Headers.Add("ContentType", "application/x-www-form-urlencoded");
                    requestMessage.Content = content;
                    var response = await httpClient.SendAsync(requestMessage);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception err)
            {
                var errMessage = err.Message;
                Console.WriteLine("In deleteVideo() error: " + err.Message);
            }
        }
