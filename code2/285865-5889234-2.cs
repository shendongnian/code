    DataSet ds = new DataSet();
    // do something with the dataset
    
    SqlDataAdapter dataAdapter = new SqlDataAdapter();
    SqlConnection cn = new SqlConnection(connString);
    cn.Open();
     
    SqlTransaction trans = cn.BeginTransaction();
    
    SqlDataAdapter dataAdapter = new SqlDataAdapter();
    
    // set the InsertCommand, UpdateCommand, and DeleteCommand for the data adapter
    
    dataAdapter.InsertCommand.Transaction = trans;
    dataAdapter.UpdateCommand.Transaction = trans;
    dataAdapter.DeleteCommand.Transaction = trans;
    
    try
    {
        dataAdapter.Update( ds );
        trans.Commit();
    }
    catch
    {
        trans.Rollback();
    }
    cn.Close();
