    private void button1_Click(object sender, EventArgs e)
    {
       conn.Open();
       System.Data.OleDb.OleDbCommand accessUpdateCommand = new System.Data.OleDb.OleDbCommand("UPDATE [user] SET [columnname] = ? WHERE id = ?", conn);
       accessUpdateCommand.Parameters.AddWithValue("columnname", "hello");
       accessUpdateCommand.Parameters.AddWithValue("id", 123); // Replace "123" with the variable where your ID is stored. Maybe row[0] ?
       da.UpdateCommand = accessUpdateCommand;
       da.UpdateCommand.ExecuteNonQuery();
       conn.Close();
    }
