    using (OracleConnection con = new OracleConnection(...))
    {
      con.Open();
      OracleCommand cmd = con.CreateCommand();
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = "update table set col1 = :param1, col2 = :param2";
      cmd.Parameters.AddWithValue("param1", 1);
      cmd.Parameters.AddWithValue("param2", "Text data");
      cmd.ExecuteNonQuery();
    }
