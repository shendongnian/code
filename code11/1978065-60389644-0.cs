       private static HttpClient client = new HttpClient();
       internal static async Task<string> RequestString(string url, string json)
        {
            try
            {
                var request = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, request);
                var response = await result.Content.ReadAsStringAsync();
                return response;
            }
            catch (HttpRequestException ex)
            {
                //handle errors
            }
            catch (Exception ex)
            {
                //handle errors               
            }
            return null;
        }
