    using System;
    
    using IronPython.Hosting;
    using System.IO;
    using System.Reflection;
    class Program
    {
        static void Main(string[] args)
        {
            var engine = Python.CreateEngine();
            var groceriesPath = Path.GetFullPath(@"Groceries.dll");
            var groceriesAsm = Assembly.LoadFile(groceriesPath);
            engine.Runtime.LoadAssembly(groceriesAsm);
            dynamic groceries = engine.ImportModule("Groceries");
            dynamic milk = groceries.ChocolateMilk();
            Console.WriteLine(milk.__repr__()); // "ChocolateMilk()"
        }
    }
