    public static async Task<TResult> PostFormUrlEncoded<TResult>(string url, IEnumerable<KeyValuePair<string, string>> postData)
    {
        using (var httpClient = new HttpClient())
        {
            using (var content = new FormUrlEncodedContent(postData))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);
                return await response.Content.ReadAsAsync<TResult>();
            }
        }
    }
