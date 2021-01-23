     var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("admin:geoserver")));
            try
            {
                var client = new HttpClient()
                {
                    DefaultRequestHeaders = { Authorization = authValue }
                };
                string url = "http://{BASE_URL}";
                client.BaseAddress = new Uri(url);
                var content = new StringContent("<workspace><name>TestTestTest</name></workspace>",
                     Encoding.UTF8, "text/xml");
                var response = await client.PostAsync($"/{PATH_TO_API}/", content);
                response.EnsureSuccessStatusCode();
                var stringResponse = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
