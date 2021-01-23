    public void ReadDatabase(string[] values)
    {
        foreach (var value in values)
        {
            using (var rd = GetData(value))
            {
                if (!rd.Read())
                    throw new OMGException("FAILED!");
                Console.WriteLine(rd["UserId"].ToString());
            }
        }
    }
    public IDataReader GetData(string value)
    {
        using(var cm = _connectionWhatever.CreateCommand())
        {
            cm.CommandText = @"
                Select UserId
                From MyTable
                Where UserName = @User
            ";
            cm.CommandType = CommandType.Text;
            cm.Parameters.AddWithValue("User", value);
            return cm.ExecuteReader();
        }
    }
