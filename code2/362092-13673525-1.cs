    if (!string.IsNullOrEmpty(json))
    {
       var settings = new JsonSerializerSettings
           {
               Error = (sender, args) =>
                       {
                           if (System.Diagnostics.Debugger.IsAttached)
                           {
                                System.Diagnostics.Debugger.Break();
                           }
                       }
           };
 
        result = JsonConvert.DeserializeObject<T>(json, settings);
    }
