    public SQLiteCommand prepareQuery(string sql)
    {
       cmd = new SQLiteCommand(sql, conn);
       return cmd;
    }
        
    public SQLiteDataReader executeReader()
    {   
        return cmd.ExecuteReader();
    }
    
    public int executeInt()
    {
       object obj = cmd.ExecuteScalar();
       return (int)obj;
    }
