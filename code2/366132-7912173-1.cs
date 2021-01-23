    string connetionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename='G:\\C#.Net\\Forms Practice\\WindowsFormsPractice1\\WindowsFormsPractice1\\WindowsFormsPractice1.mdf';Integrated Security=True;Connect Timeout=30;User Instance=True";
    SqlDataAdapter adapter = new SqlDataAdapter();
    string sql =  "insert into TBLWORKERS (first_name , last_name )" + " values('" + StartValueTextBox.Text + "', '" + EndValueTextBox.Text + ")";
    SqlConnection connection = new SqlConnection(connetionString);
    try {
    	connection.Open();
    	adapter.InsertCommand = new SqlCommand(sql, connection);
    	adapter.InsertCommand.ExecuteNonQuery();
    } catch (Exception ex) {
    	MessageBox.Show(ex.Message);
    }
