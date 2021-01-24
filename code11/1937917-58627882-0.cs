    public async Task<SomeData> GetSomeDataAsync(Uri uri)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(uri);
        SomeData result = null; 
        try
        {
            // In this case we'll expect our caller to handle a HttpRequestException
            // if this request was not successful.
            response.EnsureSuccessStatusCode();
            result = await response.Content?.ReadAsAsync<SomeData>();
        }
        finally
        {
            // Dispose of HttpResponseMessage to ensure we free up system resources 
            // and release the network connection (if that hasn't already happened).
            // Not required in a majority of common cases but always safe to do as long
           // as you have not passed the content onto other threads / consumers.
            response.Dispose(); 
        }
        // Either return the result or in this case a daft 
        // default value. It's okay for this example!
        return result ?? SomeData.Empty; 
    }
