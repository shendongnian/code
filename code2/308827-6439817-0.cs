        public class DataAccess
    {
        #region Singleton
        private static readonly object m_SyncRoot = new Object();
        private static volatile DataAccess m_SingleInstance;
        public static DataAccess Instance
        {
            get
            {
                if (m_SingleInstance == null)
                {
                    lock (m_SyncRoot)
                    {
                        if (m_SingleInstance == null)
                            m_SingleInstance = new DataAccess();
                    }
                }
                return m_SingleInstance;
            }
        }
        private DataAccess()
        {
        }
        #endregion
    }
