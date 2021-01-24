    public void PutAPI(string basicAuth, string json)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("authorization", $"Basic {basicAuth}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            var response = client.PutAsync("https://mydankapi.com/v1/put", new StringContent(json)).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);              
        }
    }
