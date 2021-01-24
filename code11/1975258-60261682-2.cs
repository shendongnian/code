    public void byteArrayToImage(byte[] bytes)
        {
            if (byteArray != null)
            {
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms, false,  false);
                
                img.Save(Server.MapPath("Photo/image.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);//Set Your image Location...
                ms.Close();
                
            }
        }
