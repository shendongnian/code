    private IDataReader GetData()
    {
        using (var cm = _databaseConnection.CreateCommand())
        {
            cm.CommandText = @"
                Select t.ID
                From table as t
                Where t.UserId = @Uid
            ";
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("Uid", userId);//imagine I declared this earlier
            return cm.ExecuteReader();
        }
    }
    private void WriteData()
    {
        using (var rd = GetData())
        {
            while (rd.Read())
            {
                idTextBox.Text = rd["ID"]; //or something like that
            }
        }
    }
