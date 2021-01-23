    public class Process
    {
        private Process(...)
        {
        }
        
        public static Process GetById(int processId)
        {
            if(ProcessExists(processId))
            {
                //get process details
            }
            else return null;
        }
    }
