    public async Task CheckWebService()
    {
        try
        {
            using (var client = new HttpClient())
            {
                await client.GetAsync("https://www.website1.com");
                await client.GetAsync("https://www.website2.com");
                await client.GetAsync("https://www.website3.com");
                await client.GetAsync("https://www.website4.com");
            }
        }
        catch (HttpRequestException Ex)
        {
            MessageBox.Show("Internet issues");
        } 
    }
