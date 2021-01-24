    public async Task<bool> Add()
    {
        using (var client = new HttpClient())
        {
            string url = Secrets.ApiAddress + $"Create{this.GetType().Name}?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
            var serializedProduct = JsonConvert.SerializeObject(this);
            var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(new Uri(url), content);
            if (result.IsSuccessStatusCode)
            {
                var rString = await result.Content.ReadAsStringAsync();
                // you don´t need to knoe the actual type, all you need is its Id, so an Entity is just fine
                Entity e = JsonConvert.DeserializeObject(rString);
                this.Id = e.Id; 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
