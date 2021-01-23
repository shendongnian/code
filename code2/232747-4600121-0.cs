    using System;
    using System.Reflection;
    using System.IO;
    
    namespace Loader
    {
        class Program
        {
            static void Main(string[] args)
            {
                string oldAppName = Path.GetFullPath("App20.exe");
                Assembly asm = Assembly.LoadFile(oldAppName);
                Console.WriteLine(asm.EntryPoint.Name);
                asm.EntryPoint.Invoke(null, new object[]{args});
            }
        }
    }
