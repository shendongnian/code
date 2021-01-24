    var allAbcTypes = myClass.child
        .SelectMany(x => x.Value
                          .ToObject<JObject>()
                          .Properties()
                          .Where(p => p.Name == "Abc")    //<= Use "Column" instead of "Abc"
                          .Select(o => new ABC            //<= Use your type that contais "Column" as a property
                          {
                               Abc = o.Value.ToString()
                          })).ToList();
