    using (SqlConnection myConnection = new SqlConnection(connectionString))
    using (SqlCommand myCommand = new SqlCommand("select * from supplier", myConnection))
    {
      myConnection.Open();
      using (SqlDataReader myReader = myCommand.ExecuteReader())
      {
        DataTable myTable = new DataTable();
        myTable.Load(myReader);
        myConnection.Close();
        dataGridView1.DataSource = myTable;
      }
    }
