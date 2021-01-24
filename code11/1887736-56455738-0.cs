    using (SqlConnection conn = new SqlConnection(@"Data Source =xxxxxxx; Integrated Security=false;Persist Security Info=true; User ID=xxxxx; Password=xxxxxx; Initial Catalog=xxxxxx"))
    {
        conn.Open();
        using (SqlTransaction trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
        {
            try 
            {
                string query = <Define your inserts here>;
                SqlCommand cmd = new SqlCommand(query, conn, trans);
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch(Exception ex) 
            { 
                trans.Rollback();    
            }
         }
        conn.Close();
    }
