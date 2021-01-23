    public static object Generate(Type t)
    {
        if(IsStatic(t))
        {
            var dictionary = new Dictionary<string, Delegate>();
            foreach (var methodInfo in t.GetMethods())
            {
                var d = Delegate.CreateDelegate(t, methodInfo);
                dictionary[methodInfo.Name] = d;
            }
            return dictionary;
        }
        return Activator.CreateInstance(t);
    }
