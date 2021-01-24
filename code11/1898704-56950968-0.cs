    Image picture = new Image();
                string queryImage = "SELECT image FROM news WHERE id = @id";
                using (MySqlConnection con1 = new MySqlConnection(servidor))
                {
                    MySqlCommand cmd1 = new MySqlCommand(queryImage, con1);
                    cmd1.Parameters.AddWithValue("@id", rd[0]);
                    con1.Open();
                    byte[] bytesImage = (byte[])cmd1.ExecuteScalar();
                    picture.ImageUrl = "data:image;base64," + Convert.ToBase64String(bytesImage);
                }  
