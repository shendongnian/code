        bool correct = false;
  
        //TODO: better create a connection here and not resuse existing one
        sqlConnection1.Open();
        try { 
          using (var cmd = new System.Data.SqlClient.SqlCommand()) {
            //DONE: Keep sql be readable
            //DONE: Make sql parametrized 
            //TODO: Do not store password as a plain text, but its hash
            cmd.CommandText = 
              @"SELECT 1      -- 1 we don't want to return password/eMail back
                  FROM Users 
                 WHERE UserPassword = @prm_Password 
                   AND Upper(UserMail) = Upper(@prm_Email)"; // me@mymail.com == Me@MyMail.com
            // Simplest; more accurate choice .Add("@prm_Password", textBox2.Text, RDBMSType)
            cmd.Parameters.AddWithValue("@prm_Password", textBox2.Text);
            cmd.Parameters.AddWithValue("@prm_Email", textBox1.Text);
            using (var reader = cmd.ExecuteReader()) {
              // correct if we read at least one record
              correct = reader.Read();
            }         
          }
        }
        finally {
          sqlConnection1.Close();
        }
        if (!correct) {
          MessageBox.Show("Wrong input... "); 
        }
        
