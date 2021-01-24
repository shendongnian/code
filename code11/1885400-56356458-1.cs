        public void ReportOnTasks()
        {
            Task.WhenAll(oPrintController.Tasks).GetAwaiter().GetResult(); //synchronously wait
    
            foreach(Task<PrintController.PrintResult> PR in oPrintController.Tasks)
            {
                // do something with the result of task
            }
        }
