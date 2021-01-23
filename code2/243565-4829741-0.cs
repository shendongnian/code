    using(TransactionScope ts = new TransactionScope()){
    
        using(SqlConnection conn = new SqlConnection(myconnstring)
        {
            conn.Open();
    ... do the call to sproc
            
            ts.Complete();
            conn.Close();
        }
    }
