    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.SqlServer.Dts.Runtime;
    
    namespace CS.ExecuteSSIS
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application app = new Application();
    
                Package package = app.LoadPackage(@"C:\Learn\SSIS\Learn.SSIS\Learn.SSIS\CallFromCS.dtsx", null);
                Variables vars = package.Variables;
                vars["Country"].Value = "US";
                vars["State"].Value = "California";
    
                DTSExecResult result = package.Execute();
    
                Console.WriteLine("Package Execution results: {0}", result.ToString());
            }
        }
    }
