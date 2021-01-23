        public void LogoDrawTransparent(PaintEventArgs e)
        {
            // Create a Bitmap object from an image file.
            Image myImg;
            Bitmap myBitmap;
            try
            {
                myImg = cls_convertImagesByte.GetImageFromByte(newImg);
                myBitmap = new Bitmap(myImg); // @"C:\Temp\imgSwacaa.jpg");  
                // Get the color of a background pixel.
                Color backColor = myBitmap.GetPixel(0, 0); // GetPixel(1, 1); 
                Color backColorGray = Color.Gray;
                Color backColorGrayLight = Color.LightGray;
                Color backColorWhiteSmoke = Color.WhiteSmoke;
                Color backColorWhite = Color.White;
                Color backColorWheat = Color.Wheat;
                // Make backColor transparent for myBitmap.
                myBitmap.MakeTransparent(backColor);
                        // OPTIONALLY, you may make any other "suspicious" back color transparent (usually gray, light gray or whitesmoke)
                myBitmap.MakeTransparent(backColorGray);
                myBitmap.MakeTransparent(backColorGrayLight);
                myBitmap.MakeTransparent(backColorWhiteSmoke);
                // Draw myBitmap to the screen.
                e.Graphics.DrawImage(myBitmap, 0, 0, pictureBox1.Width, pictureBox1.Height); //myBitmap.Width, myBitmap.Height);
            }
            catch
            {
                try { pictureBox1.Image = cls_convertImagesByte.GetImageFromByte(newImg); }
                catch { } //must do something
            }
        }
