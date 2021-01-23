       using (DbConnection connection = db.CreateConnection())
       {
         connection.Open();
         DbTransaction transaction = connection.BeginTransaction();
         try
         {
            DbCommand command = db.GetStoredProcCommand("dbo.sp1_insertItem");
            db.AddInParameter(command, "@item_name", DbType.String, itemName);
            db.ExecuteNonQuery(command, transaction);
            transaction.Commit();                   
         }
         catch
         {
           //Roll back the transaction.
           transaction.Rollback();
         }  
       }
