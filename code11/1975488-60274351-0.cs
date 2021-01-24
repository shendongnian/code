    private void button1_Click(object sender, EventArgs e)
    {
        using (OdbcConnection dbConnection = new OdbcConnection("connection string"))
        {
            dbConnection.Open();
            string sql = "Select * From Table";
            OdbcCommand com = new OdbcCommand(sql, dbConnection);
            OdbcDataReader dataReader = com.ExecuteReader();
            int i = 1;
            while (dataReader.Read())
            {
                // Add items to a listbox
                listBox1.Items.Add(i);
                listBox1.Items.Add(dataReader.GetValue(0));
                listBox1.Items.Add(dataReader.GetValue(1));
                i++;
            }
        }
    }
