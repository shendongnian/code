    using System;
    using System.Diagnostics;
    
    namespace Launcher
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    if (args.Length != 3) return;
                    string executable = args[2];
                    string directoryPath = "C:\\Program Files (x86)\\Arduino\\hardware\\tools\\";
                    Process.Start(directoryPath + executable);
                }
                catch (Exception e)
                {
                    Console.ReadLine();
                }
    
            }
        }
    }
