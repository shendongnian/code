           Runspace myRunspace = RunspaceFactory.CreateRunspace();
            myRunspace.Open();
            RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
            PSSnapInException snapInException = null;
            PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.Admin", out snapInException);
            Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
            myRunSpace.Open(rsConfig);
