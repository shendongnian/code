    using System;
    using System.Linq;
    using System.Management;
    
    namespace Bling
    {
        public static void Main()
        {
            const string Host = "127.0.0.1";
            const string Path = (@"\\" + Host + @"\root\CIMV2");
            const string QueryString = "SELECT Name FROM Win32_Process";
            const string Exe = "TEKBSS.exe";
            var query = new SelectQuery(QueryString);
            var options = new ConnectionOptions();
            options.Username = "Administrator";
            options.Password = "***";
            var scope = new ManagementScope(Path, options);
            var searcher = new ManagementObjectSearcher(scope, query);
            var processes = searcher.Get();
            bool isRunnning = processes
                .Cast<ManagementObject>()
                .Any(p => p["Name"].ToString() == Exe);
            Console.WriteLine("Is {0} running = {1}.", Exe, isRunnning);
        }
    }
