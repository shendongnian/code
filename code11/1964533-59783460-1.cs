    long recCount = 0;
    MySqlCommand mySqlCommand = new MySqlCommand();
    mySqlCommand.Connection = connection;
    mySqlCommand.CommandText = "SELECT COUNT(*) FROM nextcare_form;
    recCount = (Int64)mySqlCommand.ExecuteScalar();
    if (recCount > 0)
    {
        mySqlCommand.CommandText = "SELECT * FROM nextcare_form";
        MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
        while (mySqlDataReader.Read())
        {
            if (!DBNull.Value.Equals(mySqlDataReader.GetValue(0)))
            {
                items.Item1 = (string)mySqlDataReader.GetValue(0);
            }
            if (!DBNull.Value.Equals(mySqlDataReader.GetValue(1)))
            {
                items.Item2 = (string)mySqlDataReader.GetValue(1);
            }
            if (!DBNull.Value.Equals(mySqlDataReader.GetValue(2)))
            {
                items.Item3 = (string)mySqlDataReader.GetValue(2);
            }
            .
            .
            .
            if (!DBNull.Value.Equals(mySqlDataReader.GetValue(14)))
            {
                items.Item15 = (string)mySqlDataReader.GetValue(14);
            }
        }
    }
