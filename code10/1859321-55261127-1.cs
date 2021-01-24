    using System;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    namespace PowerShell_Export_Differences
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string directory = "C:/PowershellTest";
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript(String.Format(@"cd {0}", directory));
                powershell.AddScript(@"git init");
                powershell.AddScript(@"git diff --no-index  Text1.txt Text2.txt > Text3.diff");
                powershell.AddScript(@"git diff --no-index  Text1.txt Text2.txt > Text3.txt");
                Collection <PSObject> results = powershell.Invoke();
                Console.Read();
            }
        }
    }
