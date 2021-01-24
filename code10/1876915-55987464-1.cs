    public async Task CheckWebService()
    {
        bool success = false;
        try
        {
            using (var client = new HttpClient())
            {
                var tasks = new[]
                {
                    client.GetAsync("http://website1.com"),
                    client.GetAsync("http://website2.com"),
                    client.GetAsync("http://website3.com"),
                    client.GetAsync("http://website4.com"),
                };
                await Task.WhenAll(tasks);
                var results = tasks.Select(t => t.Result).ToList();
                if (results.All(r => r.StatusCode == System.Net.HttpStatusCode.OK))
                {
                    success = true;
                }
            }
        }
        catch (HttpRequestException exception)
        {
        }
        if (!success) MessageBox.Show("Error");
    }
