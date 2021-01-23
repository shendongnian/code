    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
                
    using(JsonWriter writer = new JsonTextWriter(sw))
    {
      var serializer = new JsonSerializer();
      serializer.Serialize(writer, myObject);
    }
