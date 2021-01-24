    private async Task<string> GetToken(string client_id, string client_secret)
        {
            AccessToken s = null;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://test.api.amadeus.com/v1/security/oauth2/token"))
                {
                    request.Content = new StringContent("grant_type=client_credentials&client_id=" + client_id + "&client_secret=" + client_secret, Encoding.UTF8, "application/x-www-form-urlencoded");
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        s = await response.Content.ReadAsAsync<AccessToken>();
                    }
                }
            }
            return s.Access_token;
        }
