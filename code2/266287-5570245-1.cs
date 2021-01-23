    public class Class1 : ServicedComponent
    {
        public Class1()
        {
            System.Diagnostics.Process process = 
                System.Diagnostics.Process.GetCurrentProcess();
            if (process.PriorityClass != 
                System.Diagnostics.ProcessPriorityClass.BelowNormal)
            {
                process.PriorityClass = 
                    System.Diagnostics.ProcessPriorityClass.BelowNormal;
            }
        }
    }
