    public static string FindFirst(string json, string propertyName)
    {
        using (StringReader sr = new StringReader(json))
        using (JsonReader reader = new JsonTextReader(sr))
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && 
                    reader.Value.ToString() == propertyName)
                {
                    return reader.ReadAsString();
                }
            }
            return null;
        }
    }
