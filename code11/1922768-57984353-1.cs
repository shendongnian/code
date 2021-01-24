    // Find all properties anywhere in the JSON whose values are arrays
    var arrayProperties = o1.Descendants()
                            .OfType<JProperty>()
                            .Where(p => p.Value.Type == JTokenType.Array);
    foreach (JProperty prop in arrayProperties)
    {
        // Replace the property value with the first child JObject of the existing value
        prop.Value = prop.Value.Children<JObject>().FirstOrDefault();
    }
