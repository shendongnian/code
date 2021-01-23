    public async Task<T> PostJsonAsync<T>(Uri uri, object dtoOut)
    {
        var content = new StringContent(JsonConvert.SerializeObject(dtoOut));
        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var results = await PostAsync(uri, content); // from previous block of code
        return JsonConvert.DeserializeObject<T>(results); // using Newtonsoft.Json
    }
