    public static void MySqlLink(string strConnection, string strCommand, Dictionary<string, object> parameters, DataTable dtTable)
    {
        dtTable.Clear();
        MySqlConnection MyConnection = new MySqlConnection(strConnection);
        MySqlCommand MyCommand = new MySqlCommand(strCommand, MyConnection);
    
        foreach (KeyValuePair<string, object> param in parameters)
        {
            MyCommand.Parameters.AddWithValue(param.Key, param.Value);
        }
    
        MySqlDataAdapter MyDataAdapter = new MySqlDataAdapter(MyCommand);
        MyDataAdapter.Fill(dtTable);
    }
