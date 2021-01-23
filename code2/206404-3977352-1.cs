        static void Log(string message) {
            // log4net code here...
        }
        
        void ExecuteScript() {
            // create the runspace configuration
            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
            // create the runspace, open it and add variables for the script
            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
            runspace.Open();
            // pass the Log function as a variable
            runspace.SessionStateProxy.SetVariable("Log", (Action<string>)Log);
            // etc...
