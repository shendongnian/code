            WSManConnectionInfo connInfo = new WSManConnectionInfo(new Uri("http://ServerName:5985/wsman"));
            Collection<PSObject> output = null;
            string command = "Get-DnsServerForwarder";
            using (Runspace remoteRS = RunspaceFactory.CreateRunspace(connInfo))
            {
                remoteRS.Open();
                using (var pShell = PowerShell.Create())
                {
                    pShell.Commands.AddCommand(command);
                    output = pShell.Invoke();
                }
            }
