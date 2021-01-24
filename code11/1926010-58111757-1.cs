    try
    {
        string query = "INSERT INTO Users (username,newpassword)values(@username,@newpassword)";
        bool CanInsertNewUser = true;
        if (txt_newusr.Text=="" || txt_password.Text == "" || txt_cnfpw.Text == "")
        {
            CanInsertNewUser = false;
            MessageBox.Show("Please enter values");
        }
        if (txt_password.Text != txt_cnfpw.Text)
        {
            CanInsertNewUser = false;
            MessageBox.Show("Password confirm password are not matching");
            txt_cnfpw.Focus();
        }
        if (CanInsertNewUser)
        {
            using (OleDbConnection conn = new OleDbConnection("GiveYourConnectionStringHere"))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = query;
                    command.Parameters.Add("@username", OleDbType.VarChar).Value = txt_newusr.Text;
                    command.Parameters.Add("@newpassword", OleDbType.VarChar).Value = txt_password.Text;
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Success");
        }
    
    }
    catch (Exception ex)
    {
        MessageBox.Show("OLEDB issues : " + ex.Message.ToString());
    }
