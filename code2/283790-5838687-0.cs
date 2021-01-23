        dataCommand.CommandType = CommandType.Text;
        dataCommand.CommandText = sqlQuery;
        dataCommand.Parameters.Add("@Today", DateTime.Today.ToString());
        //...
        dataConnection.Open();
        dataCommand.ExecuteNonQuery();
        dataConnection.Close();
