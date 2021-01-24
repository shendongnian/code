    private void button1_Click(object sender, EventArgs e)
    {
        // I assume you have a field named UserID as the primary key of your table1
        string sqlCmd = @"SELECT usertype FROM table1 WHERE UserID=@id";
        using(MySqlConnection cn = new MySqlConnection("....."))
        using(MySqlCommand cmd = new MySqlCommand(sqlCmd, cn))
        {
             cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = currentUserid;
             cn.Open();
             string usertype123 = cmd.ExecuteScalar()?.ToString();
             if (usertype123 == "admin")
             {
                 MessageBox.Show("you are an admin");
             }
             else
             {
                 MessageBox.Show("You are an user ");
             }
         }
    } 
