    var asValues = Op.Split('.');
    switch(asValues[0].ToLower())
    {
        case "customer":
            Type type = typeof(BLL.CustomerFacade);
            System.Reflection.MethodInfo method = type.GetMethod(asValues[1], System.Reflection.BindingFlags.IgnoreCase);
            if (method != null)
            {
                return method.Invoke(BLL.CustomerFacade, Parms);
            }
            break;
