    var alphaType = typeof(Alpha);
    var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => alphaType.IsAssignableFrom(t));
    var myClass = typeof(MyClass<>);
    foreach (var type in allTypes) 
    {
      var genericType = myClass.MakeGenericType(type);
    }
