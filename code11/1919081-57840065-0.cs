    if (this.OpenConnection() == true)
    {     
      SqlCommand sqlCmd = new SqlCommand();
      sqlCmd.Connection = con;
      sqlCmd.CommandType = CommandType.Text;
      sqlCmd.CommandText = "SELECT * FROM users";
      SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
      DataTable dtRecord = new DataTable();
      sqlDataAdap.Fill(dtRecord);
      dataGridView1.DataSource = dtRecord;
    }
