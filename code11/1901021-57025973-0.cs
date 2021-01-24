        static void Main(string[] args)
        {
            Process.GetProcesses() //get all process 
                         .Where(x => x.ProcessName.ToLower() // lower thier names to lower cases
                                      .Contains("note")) //where thier names conain note
                         .ToList() //convert to list
                         .ForEach(DoSomethingWithResults); //itterate over the items
        }
        private static void DoSomethingWithResults(Process obj)
        {
            //Do Something With Results
        }
