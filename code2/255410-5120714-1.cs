    var interfaceType = typeof(IExample);
    var all = AppDomain.CurrentDomain.GetAssemblies()
      .SelectMany(x => x.GetTypes())
      .Where(x => interfaceType.IsAssignableFrom(x))
      .Select(x => Activator.CreateInstance(x));
