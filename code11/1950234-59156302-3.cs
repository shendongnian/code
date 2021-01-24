    var jObject = JObject.Parse(json);
    var result = jObject["client"].Select(x=>x.ToObject<JProperty>())
                                  .Select(x=> new 
                                           {
                                              Name = x.Name, 
                                              MinVersion = x.Value["minVersion"],
                                              Tested = x.Value["minVersion"]
                                           });
