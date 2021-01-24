    public async Task<IList<T>> GetData<T>(string url) {
        try {
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var data = (JObject)JsonConvert.DeserializeObject(json);
            JArray arr = (JArray)data["resource"];
            return arr.ToObject<IList<T>>();
        } catch (InvalidCastException icEx) {
            throw new InvalidCastException("An error occurred when retrieving the data", icEx);
        }
        // Other catches
    }
