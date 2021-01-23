    var methods = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(a =>
            a.GetTypes()
                .Where(t => t.IsClass && t.IsSubclassOf(typeof (Controller))))
                .SelectMany(c => c.GetMethods(BindingFlags.Public | BindingFlags.Instance));
    foreach (var method in methods)
    {
        var myAttributes = method.GetCustomAttributes(true).OfType<MyAttribute>();
        /// ...
