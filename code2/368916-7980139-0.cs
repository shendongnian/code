try 
{
  using (SqlCeConnection oConn = new SqlCeConnection(ConnectionString))
  {
    oConn.Open();
  
    using (SqlCeTransaction transaction = oConn.BeginTransaction())
    {
        try
        {
          //delete from multiple tables using ADO.NET
          transaction.Commit();
        }
        catch 
        {
           transaction.Rollback();
           throw;
        }
    }
  }
}
catch (Exception e)
{
  // do Exception handling here
}
