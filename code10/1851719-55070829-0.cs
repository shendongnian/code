    using (var client = new HttpClient())
        {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await client.GetAsync($"<-----Tested URI HERE-------->");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                /* Read JSON from stringResult */ 
        }
