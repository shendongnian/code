    public void FillGrid()
    {
        string MyConString =
        "SERVER=myserver.com;" +
        "DATABASE=mydatabase;" +
        "UID=myuserid;" +
        "PASSWORD=mypass;";
        string sql = "SELECT clientnr, name, address FROM clients ORDER BY name";
        using (MySqlConnection connection = new MySqlConnection(MyConString))
        {
            connection.Open();
            using (MySqlCommand cmdSel = new MySqlCommand(sql, connection))
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                da.Fill(dt);
                dataGrid1.DataContext = dt;
            }
            connection.Close();
        }
    }
