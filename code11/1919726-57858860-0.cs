        static void Main(string[] args)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddCommand("Get-CimInstance");
                ps.AddParameter("-ClassName", "CIM_ManagedSystemElement");
                var outputCollection = new PSDataCollection<PSObject>();
                outputCollection.DataAdded += OutputCollection_DataAdded;
                // invoke execution on the pipeline (collecting output)
                var async = ps.BeginInvoke<PSObject, PSObject>(null, outputCollection);
                // do something else until execution has completed.
                // this could be sleep/wait, or perhaps some other work
                while (async.IsCompleted == false)
                {
                    Console.WriteLine("Waiting for pipeline to finish...");
                    Thread.Sleep(1000);
                    // might want to place a timeout here...
                }
                Console.WriteLine("Execution has stopped. The pipeline state: " + ps.InvocationStateInfo.State);
                
                // loop through each output object item
                foreach (PSObject outputItem in ps.EndInvoke(async))
                {
                    // if null object was dumped to the pipeline during the script then a null
                    // object may be present here. check for null to prevent potential NRE.
                    if (outputItem != null)
                    {
                        //TODO: do something with the output item 
                        // outputItem.BaseOBject
                    }
                }
                Console.Read();
            }
        }
        private static void OutputCollection_DataAdded(object sender, DataAddedEventArgs e)
        {
            if (sender is PSDataCollection<PSObject>)
            {
                var output = (PSDataCollection<PSObject>)sender;
                // Handle the output item here
                var caption = output.Last().Properties["Caption"];
                if (caption != null)
                {
                    Console.WriteLine($"Caption: {caption.Value}");
                }
            }
        }
