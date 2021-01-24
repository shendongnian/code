    public DataSet Select(string command)
    {
        DataSet dataSet = new DataSet();
        using (MySqlConnection conn = new MySqlConnection(LoadConnectionString()))
        {
    
            conn.Open();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter())
            {
                MySqlCommand cmd = new MySqlCommand(command, conn);
                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);
            }
            conn.Close();
        }
        return dataSet;
    }
