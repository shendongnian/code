    private DataTable GetDataTable()
    {
      string sql = "SELECT Id, Description FROM MyTable";
      using (SqlConnection myConnection = new SqlConnection(connectionString))
      {
        using (SqlCommand myCommand = new SqlCommand(sql, myConnection))
        {
          myConnection.Open();
          using (SqlDataReader myReader = myCommand.ExecuteReader())
          {
            DataTable myTable = new DataTable();
            myTable.Load(myReader);
            myConnection.Close();
            return myTable;
          }
        }
      }
    }
