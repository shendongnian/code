            PSCredential credential = new PSCredential(@"domain\user", createPassword("Pass"));
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(false, "exchange.ibm.com", 80, "/Powershell", "http://schemas.microsoft.com/powershell/Microsoft.Exchange", credential);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Default;
            Runspace runspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace(connectionInfo);
            try
            {
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                Command objCommand = new Command("");
                objCommand.Parameters.Add("Identity", @"dom\user");
                pipeline.Commands.Add(objCommand);
                Collection<PSObject> results = pipeline.Invoke();
            }
            catch 
            {
            }
            finally
            {
                runspace.Close();	            	
            }
