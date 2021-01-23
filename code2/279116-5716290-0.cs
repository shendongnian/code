    using System;
    
    namespace ConsoleApplicationN
    {
        class Program
        {
            {
                AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(CurrentDomain_AssemblyLoad);
                // You need to *DO* something here to trigger an assembly load
                // For example, open a database connection
            }
    
            static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
            {
                // This is just an example of how to use what's provided in "args"
                Console.WriteLine(args.LoadedAssembly.FullName);
            }
        }
    }
