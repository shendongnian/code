            static HttpClient client = new HttpClient();
    
    
            public async Task<string> Get(string apiURL)
            {
                HttpResponseMessage response = await client.GetAsync(apiURL);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                return await reader.ReadToEndAsync();
            }
            
        }
