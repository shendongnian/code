    public object Intercept(object proxy, MethodInfo method, object[] args)
    {
        var data = method.GetCustomAttributes(typeof(TimeAttribute), true);
        object result = default(object);
        foreach (object d in data)
        {
            if (d.GetType() == typeof(TimeAttribute)) // [Time] attribute
            {
                result = method.Time(proxy, args, Log.Write).DynamicInvoke(args);
            }
        }
        return result;
    }
