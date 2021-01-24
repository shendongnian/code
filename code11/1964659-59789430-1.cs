    dynamic evtPc1 = JsonConvert.DeserializeObject(json);
    PropertyInfo[] properties = evtPc1.GetType().GetProperties();
    for (int i = 0; i < properties.Length; i++)
    {
        var prop = properties[i];
        if (prop.Name == nameof(JToken.First) && prop.PropertyType.Name == nameof(JToken))
        {
            var token = (JToken) prop.GetValue(evtPc1);
            while (token != null)
            {
                if (token is JProperty castProp)
                    Console.WriteLine($"Property: {castProp.Name}; Value: {castProp.Value}");
                token = token.Next;
            }
        }
    }
