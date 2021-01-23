    // Contained in FirstAssembly.exe
    class Program
    {
        static void Main()
        {
            PrintLoadedAssemblies("start of Main");
            innerMain();
        }
        static void innerMain()
        {
            PrintLoadedAssemblies("start of innerMain");
            OtherClass obj;
        }
        static void PrintLoadedAssemblies(string point)
        {
            Console.WriteLine("Loaded assemblies at {0}", point);
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine(assembly.FullName);
            }
        }
    }
    // Contained in OtherAssembly.dll
    class OtherClass
    {
    }
