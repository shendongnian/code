    using(var myConnection = new SqlConnection(strConnection))
    using(var myCommand = myConnection.CreateCommand())
    {
        myCommand.CommandText = "spUpdateCMSAbout";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.AddWithValue("AboutText", txtAbout.Text);
        myConnection.Open();
        myCommand.ExecuteNonQuery();
    }
