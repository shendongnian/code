    using System.Data;
    using System.Data.SqlClient;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
      DataSet userDataset = new DataSet();
      SqlDataAdapter myCommand = new SqlDataAdapter("LoginStoredProcedure", connection);
      myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
      myCommand.SelectCommand.Parameters.Add("@au_id", SqlDbType.VarChar, 11);
      myCommand.SelectCommand.Parameters["@au_id"].Value = SSN.Text;
      myCommand.Fill(userDataset);
    }
