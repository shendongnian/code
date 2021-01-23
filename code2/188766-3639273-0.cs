    private class z_test
    {
        //set up
        private RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
        private PSSnapInException snapInException = null;
        private Runspace runSpace;
        private void RunPowerShell()
        {
            //create the runspace
            runSpace = RunspaceFactory.CreateRunspace(rsConfig);
            runSpace.Open();
            rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
            //set up the pipeline to run the powershell command 
            Pipeline pipeLine = runSpace.CreatePipeline();
            
            //create the script to run
            String sScript = "get-mailbox -identity 'rj'";
            //invoke the command
            pipeLine.Commands.AddScript(sScript);
            Collection<PSObject> commandResults = pipeLine.Invoke();
            //loop through the results of the command and load the SamAccountName into the list
            foreach (PSObject results in commandResults)
            {
                Console.WriteLine(results.Properties["SamAccountName"].Value.ToString());
            }
            pipeLine.Dispose();
            runSpace.Close();
        }
    }
}
