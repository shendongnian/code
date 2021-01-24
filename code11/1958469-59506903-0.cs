    using System;
    using IronPython.Hosting;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var py = Python.CreateEngine();
    
                var pythonVariable = py.ExecuteFile("main.py").GetVariable<string>("myVar");
                Console.WriteLine(pythonVariable);
    
                Console.Read();
    
            }
        }
    }
