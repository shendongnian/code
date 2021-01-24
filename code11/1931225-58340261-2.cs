    static HttpClient client = new HttpClient();
    static async Task<Product> GetProductAsync(string path)
    {   
        Product product = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
             var jsonString = await response.Content.ReadAsStringAsync();
             model = JsonConvert.DeserializeObject<YOUROBJECTTYPE>(jsonString);
        }
        return product;
    }
