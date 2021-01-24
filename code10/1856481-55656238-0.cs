            public static string ConnectVM(string VMName)
            {
            var error = string.Empty;
            var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            //create a pipeline
            var path = ConfigurationManager.AppSettings["VMConnectPath"];
            var pipeline = runspace.CreatePipeline();
           
            pipeline.Commands.AddScript($"& \"{path}\" localhost '{VMName}'");
            try
            {
                pipeline.Invoke();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            runspace.Close();
            return error;
        }
