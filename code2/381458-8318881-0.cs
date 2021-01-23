     public static string Serialize(object model)
     {
         var settings = new JsonSerializerSettings
                         {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                         };
         return JsonConvert.SerializeObject(model, Formatting.None, settings);
     }
