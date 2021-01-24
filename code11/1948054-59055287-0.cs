    class JsonObject
    {
        public string Name { get; set; }
    }
    
    ...
    JsonObject jo = JsonConvert.DeserializeObject<JsonObject>(missingObjectCount);
    streamWriter.Write(jo.Name);
