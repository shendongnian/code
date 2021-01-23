    class Program
    {
        static void Main()
        {
            var types = Assembly.LoadFrom(@"c:\work\Foo.dll").GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine(type.AssemblyQualifiedName);
            }
        }
    }
