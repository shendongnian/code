    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        object instance = Activator.CreateInstance(objectType);
        var props = objectType.GetTypeInfo().DeclaredProperties.ToList();
        JObject jo = JObject.Load(reader);
        foreach (JProperty jp in jo.Properties())
        {
            if (!_propertyMappings.TryGetValue(jp.Name, out var name))
                name = jp.Name;
            PropertyInfo prop = props.FirstOrDefault(pi =>
            pi.CanWrite &&
            pi.GetCustomAttribute<JsonPropertyAttribute>().PropertyName == name);
            prop?.SetValue(instance, jp.Value.ToObject(prop.PropertyType));
        }
        return instance;
    }
  
