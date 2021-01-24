            Home home = new Home();
            int userID;
            try
            {
                string ConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/Hotel.accdb";
                using (var con = new OleDbConnection(ConnString))
                {
                    con.Open();
                    //Passing the query and the connection directly to the constructor
                    using (OleDbCommand cmd1 = new OleDbCommand("SELECT UserID FROM Users WHERE Username = @UserName;", con))
                    {
                        cmd1.Parameters.Add("@UserName", OleDbType.VarChar).Value = home.LabelText;
                        userID = (int)cmd1.ExecuteScalar();
                    }
                    using (var cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Query2";
                        cmd.Parameters.Add("parUserID", OleDbType.Numeric).Value = userID;
                        cmd.Parameters.Add("parRoom_Number",OleDbType.Numeric ).Value = (int)lbRooms.SelectedItem;
                        cmd.ExecuteNonQuery();
                    }
                }
             }
           
             catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
