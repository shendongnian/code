            Article article = new Article();
            using (MySqlConnection conn = GetConnection())
            {
                MySqlCommand cmdslct = new MySqlCommand("SELECT * FROM Article WHERE ID=@id", conn);
                MySqlCommand cmdul = new MySqlCommand("UPDATE Article SET userID=@userID,Title=@Title,Body=@Body WHERE ID=@id", conn);
                conn.Open();
                cmdslct.Parameters.AddWithValue("@ID", id);
                using (MySqlDataReader reader = cmdslct.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        article = new Article()
                        {
                            userID = reader.GetInt32("userID"),
                            ID = reader.GetInt32("ID"),
                            Title = reader.GetString("Title"),
                            Body = reader.GetString("Body")
                        };
                    }
                }
                cmdul.Parameters.AddWithValue("@userID", article.userID);
                cmdul.Parameters.AddWithValue("@Title", article.Title);
                cmdul.Parameters.AddWithValue("@Body", article.Body);
                cmdul.ExecuteNonQuery();
                
                conn.Close();
            }
