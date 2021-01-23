    static void Main(string[] args)
        {
            Type t = GetTypeAtRuntime();
            Type genType = typeof(Utility<>);
            Type constructed = genType.MakeGenericType(new Type[] { t });
    
            // Now use reflection to invoke the method on constructed type
            MethodInfo mi = constructed.GetMethod("DoSomething", BindingFlags.Static);
            mi.Invoke(null, null);
