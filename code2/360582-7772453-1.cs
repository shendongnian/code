    public List<T> SelectAll<T>(Func<MySqlDataReader, T> projection)
        where T : DatabaseObject
    {
        List<T> retVal = new List<T>();
        String command = "Select * from " + GetType().Name;
        MySqlCommand cmd = DatabaseRunner.GetCommand(command);
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            retValue.Add(projection(reader));
        }
        return retVal;
    }
