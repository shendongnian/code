    private static Type Substitute(Type t, IDictionary<Type, Type> env )
    {
        // We only really do something if the type 
        // passed in is a (constructed) generic type.
        if (t.IsGenericType)
        {
            var targs = t.GetGenericArguments();
            for(int i = 0; i < targs.Length; i++)
                targs[i] = Substitute(targs[i], env); // recursive call
            t = t.GetGenericTypeDefinition();
            t = t.MakeGenericType(targs);
        }
        // see if the type is in the environment and sub if it is.
        return env.ContainsKey(t) ? env[t] : t;
    }
