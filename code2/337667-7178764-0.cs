    class Example
    {
        static void Main()
        {
            Console.WriteLine("The version of the currently executing assembly is: {0}",
                Assembly.GetExecutingAssembly().GetName().Version);
    
            Console.WriteLine("The version of mscorlib.dll is: {0}",
                typeof(String).Assembly.GetName().Version);
        }
    }
