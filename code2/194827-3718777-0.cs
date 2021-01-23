    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST");
    
            if (args.Length == 0)
            {
                string path = Assembly.GetExecutingAssembly().Location;
                Process.Start(path, "DontStartProcess");
            }
            Console.ReadLine();
        }
    }
