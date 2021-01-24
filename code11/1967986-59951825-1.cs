    public async Task ImportAwbIntegrat()
    {
        string fisier = File.ReadAllText(@"F:\Read\model.csv");
        var values = new Dictionary<string, string>
        {
            { "username", "clienttest" },
            { "client_id", "111111" },
            {"user_pass", "testing" }
        };          
        var image = File.ReadAllBytes(@"F:\Read\model.csv");
        using (var client = new HttpClient())
        {
            using (var content =
                new MultipartFormDataContent())
            {
                content.Add(new StreamContent(new MemoryStream(image)), "fisier", "model.csv");
                foreach (KeyValuePair<string, string> param in values)
                {
                    content.Add(new StringContent(param.Value), $"\"{param.Key}\"");
                }
                using (var response = await client.PostAsync("https://www.selfawb.ro/import_awb_integrat.php", content))
                {
                    var input = await response.Content.ReadAsStringAsync();
                    var responseString = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
