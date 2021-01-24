      public object Program(int id, int userId)
      {
    var serializerSettings = new JsonSerializerSettings();
    serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    var json = JsonConvert.SerializeObject(program, serializerSettings);
    return json;
    }
