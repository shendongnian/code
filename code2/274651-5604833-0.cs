    using (SqlConnection conn = new SqlConnection( connectionString ))
    {
      using (SqlCommand cmd = conn.CreateCommand() )
      {
         cmd.CommandText = "SELECT * FROM...";
         conn.open();
         using(SqlReader reader = cmd.ExecuteReader() )
         {
            if (reader.HasRows)
            {
                dataGridView1.Visible = true;
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            else
            {
               DataGridView.Visible = false;
            }
         }
      }
    }
