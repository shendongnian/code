    string ConnectionString= @"Data Source=localhost\SQLEXPRESS; 
    Initial Catalog=notepad; Integrated Security=SSPI ";
   
    string sqlStatement = "INSERT INTO dbo.Notepad(time, event) VALUES (@Date, @Event)";
    using(SqlConnection con = new SqlConnection(ConnectionString))
    using(SqlCommand cmd = new SqlCommand(sqlStatement, con))
    {
       cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Calendar1.TodaysDate;
       cmd.Parameters.Add("@Event", SqlDbType.VarChar, 100).Value = TextBoxEvent.Text.Trim();
       con.Open();
       cmd.ExecuteNonQuery();
       con.Close();
    }
