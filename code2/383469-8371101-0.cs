           using(OleDbConnection conn = OpenDbConnection())
            {
              using(OleDbCommand command = new OleDbCommand( 
                   "INSERT INTO tblUser (UserName, LoginName, Password) VALUES (@name,@login,@pwd)")) 
              {
              command.CommandType = CommandType.Text;
              command.Parameters.Add("@name", OleDbType.VarChar).Value = name; 
              command.Parameters.Add("@login", OleDbType.VarChar).Value = loginName; 
              command.Parameters.Add("@pwd", OleDbType.VarChar).Value = password; 
              command.Connection = conn; 
              
              conn.Open();
              
              command.ExecuteNonQuery();
              } 
            }
