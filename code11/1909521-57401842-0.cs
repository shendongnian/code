        public static HttpClient _HttpClient { get; } = new HttpClient(new HttpClientHandler { Credentials=new NetworkCredential("","")});
        public static async Task<string> ReadXml(string url)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
            {
                requestMessage.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
                using (var response = await _HttpClient.SendAsync(requestMessage))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
