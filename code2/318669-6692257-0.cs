    class Database : IDisposable
    {
        private SqlConnection _conn;
        public Database(string conn_str)
        {
            // Doing the connectivity
        }
        public Dataset Read(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            Dataset result = null;
            // etc...
            return result;
        }
        
        public Dispose()
        {
            _conn.Close();
        }
    }
    using(Database db = new Database(conn_string))
    {
        Dataset ds = db.Read("SELECT something FROM table");
    }
