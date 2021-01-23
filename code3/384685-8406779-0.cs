    // In Test.cs, compile to Test.exe
    using System;
    using System.Reflection;
    
    public static class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CreateDomain("NewDomain").ExecuteAssembly("Test2.exe");
        }
    }
    // In Test2.cs, compile to Test2.exe
    using System;
    using System.Diagnostics;
    using System.Reflection;
    
    class Test2
    {
        static void Main()
        {
            Console.WriteLine("Process: {0}",
                              Process.GetCurrentProcess().ProcessName);
            Console.WriteLine("Entry assembly: {0}", 
                              Assembly.GetEntryAssembly().CodeBase);
        }
    }
