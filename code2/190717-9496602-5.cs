    public static MethodInfo GetMethod(this Type t, string name, params Type[] parameters)
    {
        foreach (var method in t.GetMethods())
        {
            // easiest case: the name doesn't match!
            if (method.Name != name)
                continue;
            // set a flag here, which will eventually be false if the method isn't a match.
            var correct = true;
            if (method.IsGenericMethodDefinition)
            {
                // map the "private" Type objects which are the type parameters to
                // my public "Tx" classes...
                var d = new Dictionary<Type, Type>();
                var args = method.GetGenericArguments();
                if (args.Length >= 1)
                    d[typeof(T1)] = args[0];
                if (args.Length >= 2)
                    d[typeof(T2)] = args[1];
                if (args.Length >= 3)
                    d[typeof (T3)] = args[2];
                if (args.Length > 3)
                    throw new NotSupportedException("Too many type parameters.");
                var p = method.GetParameters();
                for (var i = 0; i < p.Length; i++)
                {
                    // Find the Refl.TX classes and replace them with the 
                    // actual type parameters.
                    var pt = Substitute(parameters[i], d);
                    // Then it's a simple equality check on two Type instances.
                    if (pt != p[i].ParameterType)
                    {
                        correct = false;
                        break;
                    }
                }
                if (correct)
                    return method;
            }
            else
            {
                var p = method.GetParameters();
                for (var i = 0; i < p.Length; i++)
                {
                    var pt = parameters[i];
                    if (pt != p[i].ParameterType)
                    {
                        correct = false;
                        break;
                    }
                }
                if (correct)
                    return method;
            }
        }
        return null;
    }
