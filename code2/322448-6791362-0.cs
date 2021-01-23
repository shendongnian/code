    public class MyInfoRepository
    {
        MyInfoDataContext _dc;
        public MyInfoRepository()
        {
            try
            {
                _dc = new MyInfoDataContext(GetDbConnection());
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogServerException(ex, TraceEventType.Error);
                throw;
            }
        }
        private static string GetDbConnection()
        {
            // if no connection string return empty which will stop processing
            if (ConfigurationManager.ConnectionStrings["MyInfo"] == null)
            {
                throw new ConfigurationErrorsException("No connection string specified.");
            }
            string connection = ConfigurationManager.ConnectionStrings["MyInfo"].ConnectionString;
            return connection;
        }
    ...
