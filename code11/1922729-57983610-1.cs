    JObject root = JObject.Parse(json);
    JProperty arrayProp = root.Properties()
                              .Where(jp => jp.Value.Type == JTokenType.Array)
                              .FirstOrDefault();
    if (arrayProp != null)
    {
        foreach (JObject item in arrayProp.Value.Children<JObject>())
        {
            root[(string)item["id"]] = item["value"];
        }
        arrayProp.Remove();
    }
    json = root.ToString();
