    class Program
    {
        static void Main(string[] args)
        {
            var info = new Action<string>(Foo).GetMethodInfo();
            Console.WriteLine("\tMicrosoft.Samples.Debugging.CorSymbolStore");
            foreach (var v in new MicrosoftDebuggingReader().Read(info))
                Console.WriteLine(v);
            Console.WriteLine("\tMono.Cecil");
            foreach (var v in new MonoCecilReader().Read(info))
                Console.WriteLine(v);
        }
        public static void Foo(string s)
        {
            for (int i; ;)
                for (double j; ;)
                    for (bool k; ;)
                        for (object m = 0; ;)
                            for (DateTime n; ;) { }
        }
    }
