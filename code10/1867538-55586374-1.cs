    public async Task<ObservableCollection<Product>> GetProducts()
    {
        try
        {
            string uri = url + "/product;
            _client.Timeout = TimeSpan.FromSeconds(300);
    
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, uri);
            var response2 = await _client.SendAsync(message);
    
            if (response2.IsSuccessStatusCode)
            {
                var content = await response2.Content.ReadAsStringAsync();
                return new ObservableCollection<Product>
                {
                    product
                };
            }
            else if (response2.StatusCode == HttpStatusCode.NotFound)
            {
                return products;
            }
    
            return products;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
