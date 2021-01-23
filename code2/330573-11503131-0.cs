         private void StopAppPool(string app_Pool , string server)
        {
            try
            {
                ConnectionOptions co = new ConnectionOptions();
                co.Username = "DomainName\\UserName";
                co.Password = "UserPassword";
                string appPool = "W3SVC/AppPools/" + app_Pool;
                co.Impersonation = ImpersonationLevel.Impersonate;
                co.Authentication = AuthenticationLevel.PacketPrivacy;
                string objPath = "IISApplicationPool.Name='" + appPool + "'";
                ManagementScope scope = new ManagementScope(@"\\" + server + @"\root\MicrosoftIISv2", co);
                using (ManagementObject mc = new ManagementObject(objPath))
                {
                    mc.Scope = scope;
                    
                    mc.InvokeMethod("Stop", null, null);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.Data);
            }
           //Console.ReadLine();
        } 
