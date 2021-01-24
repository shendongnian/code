    using System;
    using System.Diagnostics;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string option = "";
                if (args.Length > 0)
                {
                    option = args[0];
                }
    
                switch (option)
                {
                    case "WPF":
    
                        try
                        {
                            using (Process myProcess = new Process())
                            {
                                myProcess.StartInfo.UseShellExecute = false;
    
                                // Use correct path to the WPF Application
                                myProcess.StartInfo.FileName = @"C:\Users\Danny\Source\Repo\WpfApp\bin\Debug\WpfApp.exe";
                                myProcess.Start();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Press any key to continue ...");
                            Console.ReadKey();
                        }
    
                        break;
                    default:
                        DoSomething();
    
                        break;
                }
            }
    
            private static void DoSomething()
            {
                // …
                Console.WriteLine("Doing Something ...");
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
            }
        }
    }
