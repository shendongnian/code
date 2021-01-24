    static public void UpdateProfilePicture(int id,Image img)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString.connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "UPDATE Users SET UserProfilePicture = @img WHERE idUser = @id";
                    cmd.Connection = conn;
                    var userImage = ImageToByte(img);
                    var paramUserImage = new MySqlParameter("@img", MySqlDbType.Blob, userImage.Length);
                    paramUserImage.Value = userImage;
                    cmd.Parameters.Add(paramUserImage);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
