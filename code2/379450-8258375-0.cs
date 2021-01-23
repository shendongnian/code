public Bitmap loadImage(int imgID)
        {
            MySqlDataReader myData;
            MySqlCommand cmd = new MySqlCommand();
            
            string SQL;
            byte[] rawData;
            MemoryStream ms;
            UInt32 FileSize;
            Bitmap outImage;
            SQL = "SELECT ImageName, ImageSize, Image FROM Images WHERE ImageID =";
            SQL += imgID.ToString();
            try
            {
                cmd.Connection = connection;
                cmd.CommandText = SQL;
                myData = cmd.ExecuteReader();
                if (!myData.HasRows)
                    throw new Exception("There are no blobs to save");
                myData.Read();
                FileSize = myData.GetUInt32(myData.GetOrdinal("ImageSize"));
                rawData = new byte[FileSize];
                myData.GetBytes(myData.GetOrdinal("Image"), 0, rawData, 0, (Int32)FileSize);
                ms = new MemoryStream(rawData);
                outImage = new Bitmap(ms);
                ms.Close();
                ms.Dispose();
                myData.Close();
                myData.Dispose();
                cmd.Dispose();
                return outImage;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
 
