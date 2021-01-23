    using System;
    using System.Linq;
    using System.Management;
    
    namespace Bling
    {
        public static void Main()
        {
            const string Host = "vmhost01";
            const string Path = (@"\\" + Host + @"\root\CIMV2");
            const string Exe = "TEKBSS.exe";
            
            var queryString = string.Format("SELECT Name FROM Win32_Process WHERE Name = '{0}'", Exe);
            var query = new SelectQuery(queryString);
            var options = new ConnectionOptions();
            options.Username = "Administrator";
            options.Password = "*";
            var scope = new ManagementScope(Path, options);
            var searcher = new ManagementObjectSearcher(scope, query);
            bool isRunnning = searcher.Get().Count > 0;
            Console.WriteLine("Is {0} running = {1}.", Exe, isRunnning);
        }
    }
