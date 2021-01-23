    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(MemoryWrap);
            var domain1 = AppDomain.CreateDomain("Domain 1");
            var memory1 = (MemoryWrap)domain1.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
            var domain2 = AppDomain.CreateDomain("Domain 2");
            var memory2 = (MemoryWrap)domain2.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
            memory1.OpenProcess(1);
            memory2.OpenProcess(2);
            Console.WriteLine(memory1.GetOpenedId());
            Console.WriteLine(memory2.GetOpenedId());
            Console.ReadLine();
        }
    }
