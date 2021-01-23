    //search for an implicit cast operator on the target type
    MethodInfo[] methods = targetType.GetMethods();
    foreach(method in targetType.GetMethods())
    {
      if (method.Name == "op_Implicit")
      {
        ParameterInfo[] parameters = method.GetParameters();
        if (parameters.Length == 1 && parameters[0].ParameterType == value.GetType())
        {
          value = method.Invoke(obj,new object[]{value});
          break;
        }
      }
    }
