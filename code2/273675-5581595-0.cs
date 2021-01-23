    List<string> results = new List<string>();
    SqlConnection conn = new SqlConnection("Data Source = myServerAddress; Initial Catalog = myDataBase; User Id = myUsername; Password = myPassword;");
    using (SqlCommand command = new SqlCommand())
    {
      command.Connection = conn;
      command.CommandType = CommandType.Text;
      command.CommandText = "Select myColumn from myTable";
      using (SqlDataReader dr = command.ExecuteReader())
      {
        while (dr.Read())
        {
          results.Add(dr["myColumn"].ToString());
        }
      }
    }
