    static void Main(string[] args)
    {
        Type t = typeof(Letters);
    
        MethodInfo info = typeof(EnumExt).GetMethod("ToEnum", new Type[] { typeof(string) });
        var method = info.MakeGenericMethod(new Type[] { t });
        var result = (Letters)method.Invoke(null, new [] { "A" });            
                
        Console.ReadLine();
    }
