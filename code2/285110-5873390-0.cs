    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Management;
    
    namespace MyConsoleApplication
    {
        class Program
        {
            static private void GetWmiNameSpaces(string root)
            {
                try
                {
                    ManagementClass nsClass = new ManagementClass( new ManagementScope(root), new ManagementPath("__namespace"), null);
                    foreach (ManagementObject ns in nsClass.GetInstances())
                    {
                        string namespaceName = root + "\\" + ns["Name"].ToString();
                        Console.WriteLine(namespaceName);
                        //call the funcion recursively                               
                        GetWmiNameSpaces(namespaceName);
                    }
                }
                catch (ManagementException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
    
            
            static void Main(string[] args)
            {
                //set the initial root to search
                GetWmiNameSpaces("root");
                Console.ReadKey();
            }
        }
    }
