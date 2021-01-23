            PowerShell powershell = PowerShell.Create();
            String pass = "password";
            SecureString passSecure = new SecureString();
            foreach (char c in pass.ToCharArray())
            {
                passSecure.AppendChar(c);
            }
            PSCredential cred = new PSCredential("user", passSecure);
            string schemaURI = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";
            Uri connectTo = new Uri("http://192.168.69.116/powershell/");            
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(connectTo, schemaURI, cred);
            connectionInfo.MaximumConnectionRedirectionCount = 5;
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
            //connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Default;
            connectionInfo.SkipCACheck = true;
            connectionInfo.SkipCNCheck = true;
            connectionInfo.SkipRevocationCheck = true;
            Runspace remoteRunspace=null;
            try
            {
                remoteRunspace = RunspaceFactory.CreateRunspace(connectionInfo);
                remoteRunspace.Open();
            }
            catch (Exception err)
            {
                //Handle error 
            }
