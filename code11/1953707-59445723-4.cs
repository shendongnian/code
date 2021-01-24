using System;
using System.Security.Principal;
namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WindowsIdentity.GetCurrent().Name);
            Console.ReadLine();
        }
    }
}
**App2.exe**
It's another simple console application which runs `App1.exe` and also shows the user name:
using System;
using System.Diagnostics;
using System.Net;
using System.Security.Principal;
namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("Running App1");
            var info = new ProcessStartInfo();
            info.FileName = @"C:\App1\App1.exe";
            info.Domain = @"DOMAIN";
            info.UserName = @"USER";
            info.WindowStyle = ProcessWindowStyle.Normal;
            info.Password = new NetworkCredential("", "PASSWORD").SecurePassword;
            var process = Process.Start(info);
            process.WaitForExit();
            Console.WriteLine("App1 finished.");
            Console.WriteLine(WindowsIdentity.GetCurrent().Name);
            Console.ReadLine();
        }
    }
}
