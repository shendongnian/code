    try
    {
        OleDbCommand com;
        //   OleDbConnection con = new OleDbConnection(ConnectionString);
        cn.Open();
        
        string str = "select *from DatabaseLogin where user_id='" + textBox2.Text + "'";
        com = new OleDbCommand(str, cn);
        OleDbDataReader reader = com.ExecuteReader();
        while (reader.Read())
        {
            checkedListBox1.Items.Add(reader["stckdemge"].ToString());
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(" " + ex);
    }
