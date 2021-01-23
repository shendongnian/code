       DataTable dt = new DataTable();
       using (SqlConnection conn = new SqlConnection("my_connection_string"))
       {
          using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Table", conn))
          {
            conn.open();
            adapter.Fill(dt);    
          }
       }
