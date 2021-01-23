    public class TableWatcher
    {
        private string mDatabaseConnection;
        private string mTableName;
        private bool mInitialized = false;
        private double mWatchInterval = 10;
        private System.Timers.Timer mTableTimer;
        private int mInitialRowCount;
        private int mCurrentRowCount;
        private bool mIsWatching = false;
    
        public event EventHandler RowsAdded;
        public event EventHandler RowsDeleted;
    
        protected virtual void OnRowsAdded(EventArgs e)
        {
            if (RowsAdded != null)
                RowsAdded(this, e);
        }
    
        protected virtual void OnRowsDeleted(EventArgs e)
        {
            if (RowsDeleted != null)
                RowsDeleted(this, e);
        }
    
        public int InitialRowCount
        {
            get { return mInitialRowCount; }
        }
    
        public int CurrentRowCount
        {
            get { return mCurrentRowCount; }
        }
    
        public TableWatcher(string databaseConnection, string tableToWatch)
        {
    
            mDatabaseConnection = databaseConnection;
            mTableName = tableToWatch;
    
        }
    
        public void Initialize()
        {
            mInitialized = true;
            mInitialRowCount = GetCurrentRows();
            mCurrentRowCount = mInitialRowCount;
        }
    
        public void StartWatching(double interval)
        {
            if (mInitialized == false)
            {
                throw new Exception("Table Watcher has not been initialized. Call Initialize() first.");
            }
    
            if (mIsWatching == true)
            {
                throw new Exception("Table Watcher is already watching. Call Stop Watching to terminate.");
            }
    
            if (interval == 0)
            {
                throw new Exception("Interval is invalid. Please specify a value greater than 0.");
            }
    
            else
            {
                mIsWatching = true;
                mWatchInterval = interval;
                mTableTimer = new System.Timers.Timer(mWatchInterval);
                mTableTimer.Enabled = true;
                mTableTimer.Elapsed += new System.Timers.ElapsedEventHandler(mTableTimer_Elapsed);
            }
        }
    
        void mTableTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            mTableTimer.Enabled = false;
            int rowCount = GetCurrentRows();
            if (rowCount > CurrentRowCount)
            {
                OnRowsAdded(new EventArgs());
            }
    
            else if (rowCount < CurrentRowCount)
            {
                OnRowsDeleted(new EventArgs());
            }
    
            mCurrentRowCount = rowCount;
            mTableTimer.Enabled = true;
    
        }
    
        private int GetCurrentRows()
        {
            int currentRows = 0;
            using (SqlConnection conn = new SqlConnection(mDatabaseConnection))
            {
                conn.Open();
                string query = String.Format("Select Count(*) from {0}", mTableName);
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object rows = cmd.ExecuteScalar();
                    if (rows != null)
                    {
                        currentRows = Convert.ToInt32(rows);
                    }
                }
            }
    
            return currentRows;
        }
    
        public void StopWatching()
        {
            mTableTimer.Enabled = false;
            mInitialized = false;
            mIsWatching = false;
        }
    }
