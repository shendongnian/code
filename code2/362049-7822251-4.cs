    class Program
    {
        static void Main(string[] args)
        {
            LogWriter logWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
            logWriter.Write("Test");
         }
    }
