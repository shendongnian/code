    JObject o = (JObject)JsonConvert.DeserializeObject(input);
    dynamic json = new JsonObject(o);
    foreach (var x in json.groups)
    {
          var attrs = x.attributes;
          if (attrs is JArray)
          {
               foreach (var y in attrs)
               {
                   Console.WriteLine(y.value);
               }
          }
          else
          {
              Console.WriteLine(attrs.value);
          }
     }
