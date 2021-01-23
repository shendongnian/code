    using System;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("No Arguments");
                }
                else
                {
                    if (args[0] == "a")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new AboutBox1());
    
                    }
                }
    
            }
        }
    }
