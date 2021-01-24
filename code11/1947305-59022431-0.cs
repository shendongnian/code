    static void Main()
    {
        Proxy.X = 15;
        var alc = new AssemblyLoadContext("MyTest", true);
        var asm = alc.LoadFromAssemblyPath(typeof(Program).Assembly.Location);
        var proxy = asm.CreateInstance(typeof(Proxy).FullName);
        Console.WriteLine(proxy.GetType().GetMethod("Increment").Invoke(null, null));
    }
    
    class Proxy
    {
        public static int X;
        public static int Increment() => ++X;
    }
