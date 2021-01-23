    public class FTPtoFTP : IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(HTTPtoFTP));
    
        public FTPtoFTP()
        {
    
        }
    
        public virtual void Execute(JobExecutionContext context)
        {
            string[] files = GetFileList();
    
            //Code that executes, the variable context allows me to access the job information
        }
    
        string[] GetFileList()
        { 
            //Code for getting file list
        }
    }
