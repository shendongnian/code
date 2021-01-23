    public  void Main()
        {
            _Insert(new Hashtable(), "SqlTable", F1);
            _Insert(new Hashtable(), "OleTable", F2);
        }
    
        private static SqlCommand F1(string name, object[] array)
        {
            return new SqlCommand();
        }
    
        private static OleDbCommand F2(string name, object[] array)
        {
            return new OleDbCommand();
        }
    
        private void _Insert<T>(Hashtable hash, string tablename, Func<string, object[], T> command) 
        {
            if (typeof(T) == typeof(SqlCommand)) {
                SqlCommand result = command(null, null) as SqlCommand;
            }
            else if (typeof(T) == typeof(OleDbCommand)) {
                OleDbCommand result = command(null, null) as OleDbCommand;
            }
            else throw new ArgumentOutOfRangeException("command");
        }
