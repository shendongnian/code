    private static Type Substitute(Type t, IDictionary<Type, Type> env )
    {
        if (t.IsGenericType)
        {
            var targs = t.GetGenericArguments();
            for(int i = 0; i < targs.Length; i++)
                targs[i] = Substitute(targs[i], env);
            t = t.GetGenericTypeDefinition();
            t = t.MakeGenericType(targs);
        }
        return env.ContainsKey(t) ? env[t] : t;
    }
