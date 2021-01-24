    public static async Task<String> MakeRequestAsync(string url)
    {
        using(var client = new HttpClient()) // don't do this, inject it as a singleton
        {
           using (var response = await client.GetAsync(url)
              return await response.Content.ReadAsStringAsync();
        }  
    }
