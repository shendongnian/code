    public string GetTemperatureJsonParse(string inputJson)
    {
        var jsonObject = JsonConvert.DeserializeObject<dynamic>(inputJson);
        return jsonObject.Payload.Data.Temperature;
    }
