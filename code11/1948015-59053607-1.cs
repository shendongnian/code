    class Something
    {
        HttpClient client = new HttpClient();
    
        public async Task<CreateShortUrlResponse> GetResponseAsync()
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
                //you should log something here, rather than silently returning null. Or let it propagate up to where it can be handled.
                return null;
            }
        }
    }
