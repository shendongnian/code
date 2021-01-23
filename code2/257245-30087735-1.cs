    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.FileName = "Server.exe";
                p.Start();
    
                var t = new Thread(() => { while (true) { Console.WriteLine(p.StandardOutput.ReadLine()); }});
                t.Start();
    
                while (true)
                {
                    p.StandardInput.WriteLine(Console.ReadLine());
                }
            }
        }
    }
