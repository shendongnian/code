            static void Main(string[] args)
            {
                Runspace runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                
                pipeline.Commands.AddScript("Import-Module AzureAD -Force;");
                pipeline.Commands.AddScript("New-Object Microsoft.Open.AzureAD.Model.RequiredResourceAccess");
                var result = pipeline.Invoke();
    
    
                Console.WriteLine("done");
                Console.ReadLine();
            }
