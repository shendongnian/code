       DataTable dt = new DataTable();
       using (OleDbConnection conn = new OleDbConnection("my_connection_string"))
       {
          using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * from Employees", conn))
          {
            conn.open();
            adapter.Fill(dt);    
          }
       }
