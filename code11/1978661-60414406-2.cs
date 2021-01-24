    private Task GetResponseAsync(int iPage = 1) // <== Changed method name accordingly to best practices for async methods
    {
       [...]
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(newUrl);
    
                var result = await client.PostAsync(newUrl, new StringContent(""));
                if (result.IsSuccessStatusCode)
        [...]
        return _Result;
    }
