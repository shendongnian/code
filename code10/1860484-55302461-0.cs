    public async Task<string> GetStringFromAPIAsync( string resource )
    {
            // check input
            if( string.IsNullOrWhitespace(resource) ) throw new ArgumentException(nameof(resource));
            using (HttpResponseMessage result = await _httpClient.GetAsync(resource))
            using (HttpContent content = result.Content)
            {
                result.EnsureSuccessStatusCode();
                return await content.ReadAsStringAsync(); 
                // Issue in your code: 'data' was out of scope for the return.
                // string data = await content.ReadAsStringAsync();
            }
            // return data; <- "data" is not visible here!
    }
