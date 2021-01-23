     public int Saving(int s)
     {
        SqlCommand cmd = new SqlCommand();
        using (SqlConnection cn = new SqlConnection(classname.ConnectionString)){
        cn.Open();
        SqlTransaction trans;
        trans = cn.BeginTransaction();
        try{
        cmd = new SqlCommand("Storedprocedurename", cn, trans);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@spparameter", SqlDbType.Int).Value = s;
        int DataResult =Convert.ToInt32(cmd.ExecuteScalar());
        if (DataResult != 0)
        {
        trans.Commit();
        return DataResult;
        }
        else
        {
        trans.Rollback();
        return -1;
        }
        }
        catch (Exception ex)
        {
        string msg = ex.Message;
        trans.Rollback();
        trans.Dispose();
        return 0;
       }
    }
