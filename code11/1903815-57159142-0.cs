    private async Task<string> CallService()
            {
                    HttpClient client = new HttpClient();
                    var content = new StringContent("", Encoding.UTF8, "application/json");
                    client.Timeout = TimeSpan.FromMinutes(8);
    
                    var response = await client.PostAsync(url, content);
    		string data = await response.Content.ReadAsStringAsync();
    //...
            }
