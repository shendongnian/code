    string connectionString = "server=abc;database=abc;uid=abc;pwd=1234";
    using (SqlConnection mySqlConnection = new SqlConnection(connectionString))
    {
        string procedureString = "Callin_Insert";
        SqlCommand mySqlCommand = new SqlCommand(procedureString, mySqlConnection);
        mySqlCommand.CommandType = CommandType.StoredProcedure;
        mySqlCommand.Parameters.Add("@LVDate", SqlDbType.DateTime).Value = DateTime.Now;
        mySqlCommand.Parameters.Add("@LVTime", SqlDbType.DateTime).Value = DateTime.Now;
        mySqlCommand.Parameters.Add("@CuID", SqlDbType.Int).Value = CustID;
        mySqlCommand.Parameters.Add("@Type", SqlDbType.Int).Value = Keypress;
        mySqlConnection.Open();
        mySqlCommand.ExecuteNonQuery();
        //i have no idea what does this mean, data adapter is for filling Datasets and DataTables
        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
        mySqlDataAdapter.SelectCommand = mySqlCommand;
    }
