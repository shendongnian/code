    string sqlquery = "SELECT Password FROM [Member] where Username=@username";
    SqlCommand cmd = new SqlCommand(sqlquery, connect);
    cmd.Parameters.AddWithValue("@username", label_username.Text);
    cmd.Connection = connect; 
    string currentPassword = (string)cmd.ExecuteScalar();
    
    if (currentPassword == textBox_Current.Text)
    {
     // PASSWORD IS CORRECT, CHANGE IT, NOW.
    } else {
     // WOW EASY BUDDY, NOT SO FAST
    }
