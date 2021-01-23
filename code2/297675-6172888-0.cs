    DataSet ds = new DataSet(); // obtain your DataSet
    
    SqlDataAdapter dataAdapter = new SqlDataAdapter();
    SqlConnection cn = new SqlConnection(yourConnString);
    cn.Open();
    
    SqlTransaction trans = cn.BeginTransaction();
    
    SqlDataAdapter dataAdapter = new SqlDataAdapter();
    dataAdapter.InsertCommand.Transaction = trans;
    dataAdapter.UpdateCommand.Transaction = trans;
    
    try
    {
        dataAdapter.Update(ds); /// or dataAdapter.Insert(ds)
        trans.Commit();
    }
    catch
    {
        trans.Rollback();
    }
    
    cn.Close();
