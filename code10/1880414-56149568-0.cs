    public byte[] GetTileStream(long x, long y, int zoom)
        {
            byte[] retval = null;
            try
            {
                //using (SQLiteConnection conn = new SQLiteConnection(String.Format("Data Source={0};Version=3;", Path)))
                using (SQLiteConnection conn = new SQLiteConnection(String.Format("Data Source={0};Version=3;", Path),true))
                {
                    conn.Open(); // Here I was getting an exception.
                    using (SQLiteCommand cmd = new SQLiteCommand() { Connection = conn, CommandText = String.Format("SELECT * FROM tiles WHERE tile_column = {0} and tile_row = {1} and zoom_level = {2};", x, y, zoom) })
                    {
                        SQLiteDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            byte[] bytes = reader["tile_data"] as byte[];
                            retval = bytes;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                retval = null;
            }
            return retval;
        }
