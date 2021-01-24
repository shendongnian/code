    if pictureBox1.hasfile == true 
    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] img = ms.ToArray();
    
                        if (img == null)
                        {
                            com.Parameters.AddWithValue("@img", null);
                        }
                        else
                        {
                            com.Parameters.AddWithValue("@img", img);
                        }
    }
