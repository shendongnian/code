    public object FetchColumn(string query)
    {
        MySqlCommand cmd = new MySqlCommand(query, this.connection);
        MySqlDataReader reader = cmd.ExecuteReader();
        try
        {
            bool gotValue = false;
            while (reader.Read())
            {
                // do whatever you're doing to return a value
                gotValue = true;
            }
            if (gotValue)
            {
                // here, return whatever value you computed
            }
            else
            {
                return false;
            }
        }
        finally
        {
            reader.Close();
        }
    }
   
