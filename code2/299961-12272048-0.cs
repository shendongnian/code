        using System;
        using System.Management;
        ...
        private static void ShareSecurity(string ServerName)
        {
            ConnectionOptions myConnectionOptions = new  ConnectionOptions();
            
            myConnectionOptions.Impersonation = ImpersonationLevel.Impersonate;            
            myConnectionOptions.Authentication = AuthenticationLevel.Packet;
            
            ManagementScope myManagementScope = 
                new ManagementScope(@"\\" + ServerName + @"\root\cimv2", myConnectionOptions);
                    
            myManagementScope.Connect();
            
            if (!myManagementScope.IsConnected)
                Console.WriteLine("could not connect");
            else
            {
                ManagementObjectSearcher myObjectSearcher = 
                    new ManagementObjectSearcher(myManagementScope.Path.ToString(), "SELECT * FROM Win32_LogicalShareSecuritySetting");
                
                foreach(ManagementObject share in myObjectSearcher.Get())
                {
                    Console.WriteLine(share["Name"] as string);
                    InvokeMethodOptions options = new InvokeMethodOptions();
                    ManagementBaseObject outParamsMthd = share.InvokeMethod("GetSecurityDescriptor", null, options);
                    ManagementBaseObject descriptor = outParamsMthd["Descriptor"] as ManagementBaseObject;
                    ManagementBaseObject[] dacl =  descriptor["DACL"] as ManagementBaseObject[];                  
                    foreach (ManagementBaseObject ace in dacl)
                    {
                        try
                        {
                            ManagementBaseObject trustee = ace["Trustee"] as ManagementBaseObject;
                            Console.WriteLine(
                                trustee["Domain"] as string + @"\" + trustee["Name"] as string + ": " +
                                ace["AccessMask"] as string + " " + ace["AceType"] as string
                            );                            
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error: "+ error.ToString());
                        }
                    }
                }               
            }
        }
