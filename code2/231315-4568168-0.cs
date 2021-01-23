        public static Color[,] takeScreenshot()
        {
            Bitmap screenShotBMP = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,
                System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Graphics screenShotGraphics = Graphics.FromImage(screenShotBMP);
            screenShotGraphics.CopyFromScreen(System.Windows.Forms.Screen.PrimaryScreen.Bounds.X,
                System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size,
                CopyPixelOperation.SourceCopy);
            screenShotGraphics.Dispose();
            return bitmap2imagearray(screenShotBMP);
        } 
        public static Color[,] bitmap2imagearray(Bitmap b)
        {
            Color[,] imgArray = new Color[b.Width, b.Height];
            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    imgArray[x, y] = b.GetPixel(x, y);
                }
            }
            return imgArray;
        }
