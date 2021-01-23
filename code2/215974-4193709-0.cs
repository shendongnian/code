    using (SqlConnection db = new SqlConnection("connectionstring"))
    {
          db.Open();
          SqlTransaction transaction = db.BeginTransaction();
          try 
          {
             new SqlCommand("update statement", db, transaction).ExecuteNonQuery();
             new SqlCommand("another statement", db, transaction).ExecuteNonQuery();
             // additional operations here
             transaction.Commit();
          } 
          catch (SqlException sqlError) 
          {
             transaction.Rollback();
          }
    }
