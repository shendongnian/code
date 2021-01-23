    List<int> ReadList(IDataReader reader)
    {
        List<int> list = new List<int>();
        int column = reader.GetOrdinal("MyColumn");
        while (reader.Read())
        {
            list.Add(reader.GetInt32(column));
        }
        return list;
    }
