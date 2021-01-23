    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    namespace MyProcess
    {
        class MyProcess
        {
            public static void Main()
            {
                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = "cmd.exe";
                    myProcess.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
