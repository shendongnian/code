    var output = JsonConvert.DeserializeObject<dynamic>("{ }");
    if (((JObject)output).Count == 0)
    {
        // The object is empty
    }
