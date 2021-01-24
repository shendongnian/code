    class Something
    {
        HttpClient client = new HttpClient();
    
        public async CreateShortUrlResponse GetResponseAsync()
        {
            string response = string.Empty;
    
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
    
                {
                    var responseMessage = await client.PostAsync("https://myapi/createshorturl", content);
                    response = await responseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CreateShortUrlResponse>(response);
                }
            }
            catch (Exception x)
            {
                return null;
            }
        }
    }
