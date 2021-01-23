    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management;
    namespace MyProgram
    {
        class Program
        {
            static void Main(string[] args)
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Authentication = AuthenticationLevel.PacketPrivacy;
                options.Username = "somedomain\\username";
                options.Password = "password";
                ManagementPath path = new ManagementPath();
                path.Server = "someserver";
                path.NamespacePath = "root/MicrosoftIISv2";
                ManagementScope scope = new ManagementScope(path, options);
                string Query = "select * from IIsWebVirtualDirSetting";
                using (ManagementObjectSearcher search = new ManagementObjectSearcher(scope, new ObjectQuery(Query)))
                {
                    ManagementObjectCollection results = search.Get();
                    foreach (ManagementObject obj in results)
                    {
                        Console.WriteLine(obj.Properties["Name"].Value);
                    }                
                }          
                Console.ReadLine();
            }
        }
    }
