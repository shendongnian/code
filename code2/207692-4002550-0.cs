    public static string Cascade(params string[] jsonArray)
    {
        JObject result = new JObject();
        foreach (string json in jsonArray)
        {
            JObject parsed = JObject.Parse(json);
            foreach (var property in parsed)
                result[property.Key] = property.Value;
        }
        return result.ToString();
    }
