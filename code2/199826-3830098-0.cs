    public class FTPtoFTP : IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(HTTPtoFTP));
    
        public FTPtoFTP()
        {
    
        }
    
        public virtual void Execute(JobExecutionContext context)
        {
            //Code that executes, the variable context allows me to access the job information
            string[] file_list = GetFileList();
            // use file_list
        }
    
        private string[] GetFileList()
        { 
           //Code for getting file list
           return list_of_strings;
        }
    }
