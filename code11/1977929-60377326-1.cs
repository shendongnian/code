            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();
                com.Parameters.AddWithValue("@img", img);
            }
            else
            {
                com.Parameters.Add("@img", SqlDbType.VarBinary, 0).Value = DbNull.Value;
            }
