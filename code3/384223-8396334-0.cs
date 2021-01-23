            string con_string = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Database.mdf;Integrated Security=True;User Instance=True";
            string query = "SELECT * FROM Users WHERE UseName='" + txtUserName.Text.ToString() + "' AND Password='" + txtPassword.Text + "'";
            SqlConnection Con = new SqlConnection(con_string);
            SqlCommand Com = new SqlCommand(query, Con);
            Con.Open();
            SqlDataReader Reader;
            Reader = Com.ExecuteReader();
            if (Reader.Read())
            {
                lblStatus.Text="Successfully Login";
            }
            else
            {
               lblStatus.Text="UserName or Password error";
            }
            Con.Close();
