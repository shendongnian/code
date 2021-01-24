    public static bool JoinAndSetName(string newName, string target, string username, string password)
        {
            // Get WMI object for this machine
            using (ManagementObject computerSystem = new ManagementObject("Win32_ComputerSystem.Name='" + Environment.MachineName + "'"))
            {
                try
                {
                    object[] methodArgs = { "MyDomain.com", password, username, target, 3 };
                    computerSystem.Scope.Options.Authentication = System.Management.AuthenticationLevel.PacketPrivacy;
                    computerSystem.Scope.Options.Impersonation = ImpersonationLevel.Impersonate;
                    computerSystem.Scope.Options.EnablePrivileges = true;
                    object joinParams = computerSystem.InvokeMethod("JoinDomainOrWorkgroup", methodArgs);                 
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("Join to domain didn't work");
                    return false;
                }
                // Join to domain worked - now change name
                ManagementBaseObject inputArgs = computerSystem.GetMethodParameters("Rename");
                inputArgs["Name"] = newName;
                inputArgs["Password"] = password;
                inputArgs["UserName"] = username;
                // Set the name
                ManagementBaseObject nameParams = computerSystem.InvokeMethod("Rename", inputArgs, null);
                if ((uint)(nameParams.Properties["ReturnValue"].Value) != 0)
                {
                    MessageBox.Show("Name change didn't work");
                    return false;
                }
                // All ok
                return true;
            }
        }
