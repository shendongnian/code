    private void button1_Click(object sender, EventArgs e)
    {
       conn.Open();
       string query = "UPDATE [user] SET [columnname] = ? WHERE id = ?";
       var accessUpdateCommand = new OleDbCommand(query, conn);
       accessUpdateCommand.Parameters.AddWithValue("columnname", "hello");
       accessUpdateCommand.Parameters.AddWithValue("id", 123); // Replace "123" with the variable where your ID is stored. Maybe row[0] ?
       da.UpdateCommand = accessUpdateCommand;
       da.UpdateCommand.ExecuteNonQuery();
       conn.Close();
    }
