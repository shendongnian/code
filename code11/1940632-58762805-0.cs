    [HttpPost]
    public string PostData([FromBody]JsonElement data)
    {
        var param = "";
        var json = JsonSerializer.Serialize<dynamic>(data);
        using (JsonDocument doc = JsonDocument.Parse(json))
        {
            JsonElement root = doc.RootElement;
            var param1 = root.GetProperty("param1");
            var param1data = param1.GetString();
            var param2 = root.GetProperty("param2");
            var param2data = param2.GetString();
            param = param1data + param2data;
        }
        return param;
    }
