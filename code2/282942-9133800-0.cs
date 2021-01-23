    public static void Process(TSource source)
    {
        foreach (PropertyInfo p in target.GetType().BaseType.GetProperties(flags))
        {
            object[] attr = p.GetCustomAttributes(true);
        } 
    }
