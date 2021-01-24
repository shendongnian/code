      [HttpGet, Route("values/get")]
            public async Task<string> Get(string resulted)
            {
                string res = "";
                using (var client = new HttpClient())
                {
                    // HTTP POST
                    client.BaseAddress = new Uri("https://api.elliemae.com/");          
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(resulted)));
                    var response = client.GetAsync("/encompass/v1/loans/{ea7c29a6-ee08-4816-99d2-fbcc7d15731d}?Authorization=Bearer "+resulted+"&Content-Type=application/json").Result;
                    using (HttpContent content = response.Content)
                    {
                        // ... Read the string.
                        Task<string> result = content.ReadAsStringAsync();
                        res = result.Result;
                    }
                }
                return res;
            }
