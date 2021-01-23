    using System;
    using System.Diagnostics;
    using System.Reflection;
    
    class Test
    {
        static void Main(string[] args)
        {
            Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            string cmd = Environment.CommandLine;
            
            Process again = new Process();
            again.StartInfo.FileName = ass.Location;
            again.StartInfo.Arguments = args[0];
            Console.WriteLine("Running with: " + args[0]);
            System.Threading.Thread.Sleep(1000);
            again.Start();
            return;
        }
    }
