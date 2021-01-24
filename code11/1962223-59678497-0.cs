    private static async Task<string> SendGetRequest(string url)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationType, accessToken);
            string responseString = string.Empty;
            var response = await httpClient.GetAsync(url);
    
            if (response.IsSuccessStatusCode)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }
            else
            {
               ...
            }
    
            return responseString;
        }
    
        private static async Task SendPostRequest(string url, object payLoad)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationType, accessToken);
                var stringContent = new StringContent(JsonConvert.SerializeObject(payLoad), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, stringContent).ConfigureAwait(false);
    
                if (!response.IsSuccessStatusCode)
                {
                    ...
                }
            }
            catch (InvalidOperationException ex)
            {
                ...
            }
            catch (Exception ex)
            {
                ...
            }
        }
