            string conn = "Data Source=servername\\SQL2008; Initial Catalog=MyData;UID=MyID;PWD=mypassword;";
            using (SqlConnection dbConn = new SqlConnection(conn))
            {
                dbConn.Open();
                string sql = "SELECT DATALENGTH(image_column), image_column FROM images_table ";
                using (SqlCommand cmd = new SqlCommand(sql, dbConn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int size = reader.GetInt32(0);
                            byte[] buff = new byte[size];
                            reader.GetBytes(1, 0, buff, 0, size);
                            MemoryStream ms = new MemoryStream(buff, 0, buff.Length);
                            ms.Write(buff, 0, buff.Length);
                            StoreImage(Image.FromStream(ms, true));
                        }
                    }
                }
            }
