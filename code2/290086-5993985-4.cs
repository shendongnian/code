    // find currently executing assembly
    Assembly curr = Assembly.GetExecutingAssembly();
    // get the directory where this app is running in
    string currentLocation = Path.GetDirectoryName(curr.Location);
    // find all assemblies inside that directory
    string[] assemblies = Directory.GetFiles(currentLocation, "*.dll");
    // enumerate over those assemblies
    foreach (string assemblyName in assemblies)
    {
       // load assembly just for inspection
       Assembly assemblyToInspect = Assembly.ReflectionOnlyLoadFrom(assemblyName);
       if (assemblyToInspect != null)
       {
          // find all types
          Type[] types = assemblyToInspect.GetTypes();
          // enumerate types and determine if this assembly contains any types of interest
          // you could e.g. put a "marker" interface on those (service implementation)
          // types of interest, or you could use a specific naming convention (all types
          // like "SomeThingOrAnotherService" - ending in "Service" - are your services)
          // or some kind of a lookup table (e.g. the list of types you need to find from
          // parsing the app.config file)
          foreach(Type ty in types)
          {
             // do something here
          }
       }
    }
