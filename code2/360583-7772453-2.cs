    public List<T> SelectAll<T>() where T : DatabaseObject, new()
    {
        List<T> retVal = new List<T>();
        String command = "Select * from " + GetType().Name;
        MySqlCommand cmd = DatabaseRunner.GetCommand(command);
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            T value = new T();
            value.Initialize(reader);
            retValue.Add(value);
        }
        return retVal;
    }
