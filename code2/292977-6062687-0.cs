    using (SqlConnection cn = new SqlConnection(cnstr), SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable))
    {
        cn.Open();
    
    }
