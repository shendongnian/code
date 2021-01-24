    static void Main(string[] args)
        {
            using (PowerShell psInstance = PowerShell.Create())
            {
                
                Console.Clear();
                string pscontent = File.ReadAllText(@".\Scripts\" + args[0]);
                psInstance.AddScript(pscontent)
                .AddParameter("Servicenumber", args[1])
                .AddParameter("APIVersion", args[2]);
                PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();
                outputCollection.DataAdded += OutputCollection_DataAdded;
                psInstance.Streams.Error.DataAdded += Error_DataAdded;
                IAsyncResult results = psInstance.BeginInvoke<PSObject, PSObject>(null, outputCollection);
                Console.WriteLine("Script status: " + psInstance.InvocationStateInfo.State, Console.ForegroundColor=ConsoleColor.Green);
                Console.ResetColor();
                foreach(PSObject outItem in outputCollection)
                {
                    Console.WriteLine(outItem.BaseObject.ToString());
                }
            }
        }
        private static void Error_DataAdded(object sender, DataAddedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Something got jacked up:\n");
            Console.ResetColor();
        }
        private static void OutputCollection_DataAdded(object sender, DataAddedEventArgs e)
        {
            //Console.WriteLine("Something added to output\n");
        }
