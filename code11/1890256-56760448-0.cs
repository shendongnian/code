     public async Task<string> Get(string Accesstoken)
        {
             string res = "";
             using (var client = new HttpClient())
            {
                Accesstoken = Accesstoken.Substring(17, 28);
                client.BaseAddress = new Uri("https://api.elliemae.com/");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Accesstoken);
                var response = client.GetAsync("encompass/v1/loans/ea7c29a6-ee08-4816-99d2-fbcc7d15731d").Result;
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                }
