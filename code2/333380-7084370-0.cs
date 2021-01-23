    public static class Quickbooks
    {
        public static QuickbookSession CreateSession()
        {
            return new QuickbookSession();
        }
    }
    public class QuickbookSession : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuickbookSession"/> class.
        /// </summary>
        internal QuickbookSession()
        {
            this.SessionManager = new QBSessionManager();
            this.SessionManager.OpenConnection2(
                ConfigurationManager.AppSettings["QuickbooksApplicationId"],
                ConfigurationManager.AppSettings["QuickbooksApplicationName"],
                Utils.GetEnumValue<ENConnectionType>(ConfigurationManager.AppSettings["QuickbooksConnectionType"]));
            var file = Quickbook.QuickbookDatabaseFilePath;
            if (string.IsNullOrEmpty(file))
            {
                file = ConfigurationManager.AppSettings["QuickbooksDatabaseLocalPath"];
            }
            this.SessionManager.BeginSession(file, Utils.GetEnumValue<ENOpenMode>(ConfigurationManager.AppSettings["QuickbooksSessionOpenMode"]));
        }
        /// <summary>
        /// Gets the Quickbook session manager that is owning this message.
        /// </summary>
        public QBSessionManager SessionManager { get; private set; }
        public QuickbookMessage CreateMessage()
        {
            return new QuickbookMessage(this.SessionManager);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // get rid of managed resources
            }
            this.SessionManager.EndSession();
            this.SessionManager.CloseConnection();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(this.SessionManager);
        }
    }
