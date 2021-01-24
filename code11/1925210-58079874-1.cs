     while (dr.Read())
        {
            try
            {
                getImg = (byte[])dr["Photograph"];
                personId = Convert.ToString(dr["person_id"]);
                MemoryStream str = new MemoryStream(getImg);
                using (Bitmap bitmap = new Bitmap(Image.FromStream(str))) {
                    BitmapImg = ImageToByte(bitmap);
                    dt.Rows.Add(personId, bitmap);
               }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLine(personId + ex.Message.ToString());
            }
        }
