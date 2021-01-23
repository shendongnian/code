    string json = w.JSON;
    var serializer = new JavaScriptSerializer();
    serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
    DynamicJsonConverter.DynamicJsonObject obj = 
          (DynamicJsonConverter.DynamicJsonObject)serializer.Deserialize(json, typeof(object));
