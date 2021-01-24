        protected void GetRedPixelCoordinates(HttpPostedFile postedFile)
        {
            try
            {
                Bitmap image1 = new System.Drawing.Bitmap(postedFile.InputStream);
                //System.Drawing.Imaging.PixelFormat pform = image1.PixelFormat;
                int xPos = 0;
                int yPos = 0;
                bool found = false; <--  HERE
                for (xPos = 0; xPos < image1.Width - 1 && !found; xPos++) <-- HERE
                {
                    for (yPos = 0; yPos < image1.Height - 1 && !found; yPos++) <-- HERE
                    {
                        Color pixelColor = image1.GetPixel(xPos, yPos);
                        if (pixelColor.R == 255 && pixelColor.G == 0 && pixelColor.B == 0)
                        {
                            lblRedDotTop.Text = xPos.ToString().Trim() + " Pixels";
                            lblRedDotLeft.Text = yPos.ToString().Trim() + " Pixels";
                            found = true; <-- HERE
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
