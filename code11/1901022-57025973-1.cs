        static void Main(string[] args)
        {
            Process.GetProcesses() //get all process 
                         .Where(x => x.ProcessName.ToLower() // lower their names to lower cases
                                      .Contains("note")) //where their names contain note
                         .ToList() //convert to list
                         .ForEach(DoSomethingWithResults); //iterate over the items
        }
        private static void DoSomethingWithResults(Process obj)
        {
            //Do Something With Results
        }
