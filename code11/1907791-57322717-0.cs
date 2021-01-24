    public async Task<T> GetData(string reference)
    {
        var data = await _client.GetItemAsync(
            "my-data",
            new Dictionary<string, AttributeValue>
            {
                {"reference", new AttributeValue {S = reference}}
            }
        );
    
        return data.Item.Values.First().S;
    }
