        public static SalesBuddy.Form1 CurrentForm = null;
        public RunMyTask()
        {
        }
        public void Execute(IJobExecutionContext context)
        {
            if (CurrentForm.InvokeRequired)
            {
                SalesBuddy.Form1.ExecuteCallback x = new SalesBuddy.Form1.ExecuteCallback(CurrentForm.Execute);
                CurrentForm.Invoke(x);
            }
            else
            {
                CurrentForm.Execute();
            }
        }
