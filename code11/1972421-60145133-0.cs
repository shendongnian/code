    async Task<HttpResponseMessage> 
                      PostGenericMessage<T>(string apiEndpoint, T typeofYourClass) where T : class
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("uri");
            var postTask = client.PostAsJsonAsync(apiEndpoint, typeofYourClass);
            return await postTask;
        }
    }
