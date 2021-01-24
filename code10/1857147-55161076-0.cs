                 string playerInsert = "insert into players(username,password) VALUES (@user,@password)";
                    MySqlCommand command1 = new MySqlCommand(playerInsert, connection1);
                    command1.Parameters.AddWithValue("@user", player.SocialClubName);
                    command1.Parameters.AddWithValue("@password", password);
                    command1.ExecuteNonQuery(); //execute the query
                    connection1.Close();
