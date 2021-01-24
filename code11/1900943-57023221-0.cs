    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    builder["Server"] = @"Server_Name";
    builder["User ID"] = "DB_Username";
    builder["Password"] = "DB_Username_Password";
    builder["Database"] = "DB_Name";
    SqlConnection connection = new SqlConnection(builder.ToString());
    SqlCommand cmd = new SqlCommand("My_Stored_Procedure", connection);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@TextBoxContent", SqlDbType.Varchar).Value = MyTextBox.Text; // Your textbox content
    connection.Open(); // Connection must be opened
    cmd.ExecuteNonQuery();
    connection.Close(); // You can't have multiple connections open
