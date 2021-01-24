    static public Image GetUserImageById(int id)
        {
            MySqlDataAdapter da;
            using (MySqlConnection conn = new MySqlConnection(ConnectionString.connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SELECT UserProfilePicture FROM Users WHERE idUser = @id";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", id);
                    da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    byte[] img = (byte[])table.Rows[0][0];
                    MemoryStream ms = new MemoryStream(img);
                    Image image;
                    if (ms.Length > 0) image = Image.FromStream(ms);
                    else
                    image = null;
                    da.Dispose();
                    return image;
                }
            }
        }
