    using System;
    using System.Diagnostics;
    
    namespace Exe
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process proc = new System.Diagnostics.Process();
                //In the Linux shell: dpkg-query -W -f=' ${db:Status-Status} ' mariadb*:
                ProcessStartInfo pi = new ProcessStartInfo("dpkg-query");
                pi.ArgumentList.Add("-W");
                pi.ArgumentList.Add("-f= ${db:Status-Status} ");
                pi.ArgumentList.Add("mariadb*");
                pi.UseShellExecute = false;
                proc.StartInfo = pi;
                proc.Start();
                do { System.Threading.Thread.Sleep(50); } while (proc.HasExited == false);
                Environment.Exit(0);
            }
        }
    }
