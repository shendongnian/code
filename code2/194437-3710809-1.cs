    // current assembly -> all types that have basetype controller -> grab methods
    foreach(var type in System.Reflection.Assembly.GetCallingAssembly().GetTypes().Where(t=>
        typeof(Controller).IsAssignableFrom(t))))
    {
        foreach(var methodInfo in type.GetMethods())
        {
            if (methodInfo.GetCustomAttributes(typeof(MyAttribute), false).Count() > 0)
            {
                var action = methodInfo.Name;
                var controller = type.Name;
            }
        }
    }
