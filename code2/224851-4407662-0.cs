    using (SqlConnection cn = new SqlConnection(
                @"Data Source=COMPAQ-PC-PC\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True"))
    {
        SqlCommand cmd = new SqlCommand(
            string.Format(@"select username,password 
                            from login where username like '{0}' 
                            and password like '{1}'", 
                                tbUserName.Text, tbPassword.Text), cn);
        cn.Open();
        if (cmd.ExecuteScalar() == null)
            MessageBox.Show("Please provide the correct username and password", 
                "Invalaid Username OR Password", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        else
        {
            Form2 login_Success = new Form2();
            login_Success.ShowDialog();
        }
    }
