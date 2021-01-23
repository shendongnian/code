        private void byteArrayToImage(byte[] byteArray)
        {
            if (byteArray != null)
            {
                MemoryStream ms = new MemoryStream(byteArray);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms, false,  false);
                /*last argument is supposed to turn Image data validation off*/
                img.Save(Server.MapPath("Photo/image.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Close();
                //Image1.ImageUrl = Server.MapPath("Photo/image.jpg");
                imgViewPhoto.ImageUrl = ConfigurationManager.AppSettings["PhotoFolder"].ToString() + "Photo/image.jpg";   
            }
        }
