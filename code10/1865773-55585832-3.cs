    public class MbTilesReader
    {
        private string _mbTilesFilename;
        public MbTilesReader(string mbTilesFilename)
        {
            _mbTilesFilename = mbTilesFilename;
        }
        public byte[] GetImageData(int x, int y, int zoom)
        {
            byte[] imageData = null;
            using (SQLiteConnection conn = new SQLiteConnection(string.Format("Data Source={0};Version=3;", _mbTilesFilename)))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT * FROM tiles WHERE tile_column = @x and tile_row = @y and zoom_level = @z";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Add(new SQLiteParameter("@x", x));
                    cmd.Parameters.Add(new SQLiteParameter("@y", y));
                    cmd.Parameters.Add(new SQLiteParameter("@z", zoom));
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        imageData = reader["tile_data"] as byte[];
                    }
                }
            }
            return imageData;
        }
    }
