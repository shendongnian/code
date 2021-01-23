    MethodInfo SmarterGetMethod(object o, string nameMethod, params object[] args)
    {
    var methods = o.GetType().GetMethods();
    var min = args.Length;
    var values = new int[methods.Length];
    values.Initialize();
    //Iterates through all methods in o
    for (var i = 0; i < methods.Length; i += 1)
    {
        if (methods[i].Name == nameMethod)
        {
            var parameters = methods[i].GetParameters();
            if (parameters.Length == min)
            {
                //Iterates through parameters
                for (var j = 0; j < min; j += 1)
                {
                    if (args[j] == null)
                    {
                        if (parameters[j].ParameterType.IsValueType)
                        {
                            values[i] = 0;
                            break;
                        }
                        else
                        {
                            values[i] += 1;
                        }
                    }
                    else
                    {
                        if (parameters[j].ParameterType != args[j].GetType())
                        {
                            values[i] = 0;
                            break;
                        }
                        else
                        {
                            values[i] += 2;
                        }
                    }
                }
                if (values[i] == min * 2) //Exact match                    
                    return methods[i];
            }
        }
    }
    
    var best = values.Max();
    if (best < min) //There is no match
        return null;
    //Iterates through value until it finds first best match
    for (var i = 0; i < values.Length; i += 1)
    {
        if (values[i] == best)
            return methods[i];
    }
    return null; //Should never happen
    }
