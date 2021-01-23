    public void CallAllMethods(object instance)
    {
        foreach (MethodInfo method in instance.GetType().GetMethods())
        {
            if (method.IsGenericMethod || method.DeclaringType == typeof(object))
            {
                // skipping, System.Object method or a generic method
                continue;
            }
    
            var defaultParamValues = method.GetParameters().Select(p => GetDefaultValue(p.ParameterType)).ToArray();
            Console.WriteLine("Invoking {0} with param values {1}", method.Name, string.Join(", ", defaultParamValues));
            object retVal = method.Invoke(instance, defaultParamValues);
    
            if (method.ReturnType != typeof(void))
            {
                Console.WriteLine("  and returned a value of {0}", retVal);
            }
        }
    }
    
    public static object GetDefaultValue(Type type)
    {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }
