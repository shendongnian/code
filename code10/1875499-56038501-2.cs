    public bool InsertProcessToAS400(iDB2Connection cn, Order order)
    {
          bool result = false;
          try
          {
            DB2Transaction myTrans;
            var code = GetCodeOfDdtConnected(cn, order.Code);
            iDB2Command cmd = cn.CreateCommand();
            // Start a local transaction
            myTrans = cn.BeginTransaction();
            // Assign transaction object for a pending local transaction
            cmd.Transaction = myTrans;
    
            cmd.CommandText =$"INSERT INTO PCM00F " +
            $"(Code)" +
            $"VALUES(@P1)";
    
            var p = new iDB2Parameter("@P1", iDB2DbType.iDB2VarChar);
            p.Value = code; cmd.Parameters.Add(p);
    
            cmd.ExecuteNonQuery();
            myTrans.Commit();
            result = true;
           }
           catch (Exception ex)
           {
             myTrans.Rollback();
             log.Error("An error occurred while Synchronizer (INSERT): ", ex);
             result = false;
           }
           finally
           {
             cmd.Dispose(); cmd = null;
           }
    
           return result;
    }
