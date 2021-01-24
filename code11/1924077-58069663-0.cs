    private void OnDataLoaded(byte[] data)
    {
        using (var reader = new BsonReader(new MemoryStream(data)))
        {
            var serializer = JsonSerializer.Create(new JsonSerializerSettings());
            var json = serializer.Deserialize<JObjectWrapper>(reader).Value;
            Debug.WriteLine(json);
        }
    }
    private class JObjectWrapper
    {
        public JObject Value { get; set; }
    }
