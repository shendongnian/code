    string ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename='G:\\C#.Net\\Forms Practice\\WindowsFormsPractice1\\WindowsFormsPractice1\\WindowsFormsPractice1.mdf';Integrated Security=True;Connect Timeout=30;User Instance=True";
    string sql = "insert into TBLWORKERS (first_name , last_name )" + " values('" + StartValueTextBox.Text + "', '" + EndValueTextBox.Text + ")";
    using (SqlConnection connection = new SqlConnection(
               ConnectionString))
    {
        SqlCommand command = new SqlCommand(sql , connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
