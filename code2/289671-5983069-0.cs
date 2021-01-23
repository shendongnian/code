        private static void DemoFunc() 
           {
              SqlConnection conn = new SqlConnection("");//conection string here
              SqlTransaction transaction;
              SqlCommand cmd;
        
              conn.Open();
              transaction = conn.BeginTransaction();
              try 
              {
                 cmd = new SqlCommand("Your Query1", conn, transaction);//Your query in place of Your Query1 
                 cmd.ExecuteNonQuery();
        
                 cmd = new SqlCommand("Your Query2", conn, transaction);//Your query in place of Your Query2         
     cmd.ExecuteNonQuery();
                 transaction.Commit();
              } 
              catch (SqlException sqlError) 
              {
                 transaction.Rollback();
              }
              conn.Close();
           }
