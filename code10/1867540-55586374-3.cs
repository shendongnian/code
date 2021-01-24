    public async Task<ObservableCollection<Product>> GetProducts()
    {
        try
        {
            string uri = url + "/product;
            _client.Timeout = TimeSpan.FromSeconds(300);
    
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, uri);
            var response2 = await _client.SendAsync(message);
    
    		ObservableCollection<Product> products = new ObservableCollection<Product>();
            if (response2.IsSuccessStatusCode)
            {
                var content = await response2.Content.ReadAsStringAsync();
                Product product = JsonConvert.DeserializeObject<Product>(content);
                products.Add(product);
            }
            
            return products;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
