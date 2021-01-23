    string sql = "INSERT INTO T (A, B, C) VALUES (@A, @B, @C)";
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
       conn.Open();
       foreach (DataRow r in myTable.Rows)
       {
          SqlCommand cmd = conn.CreateCommand();
          cmd.CommandText = sql;
          cmd.Parameters.AddWithValue("@A", r["A"]);
          cmd.Parameters.AddWithValue("@B", r["B"]);
          cmd.Parameters.AddWithValue("@C", r["C"]);
          cmd.ExecuteNonQuery();
       }
    }
