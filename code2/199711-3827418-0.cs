         // the surface that we are focusing upon
         Rectangle rect = new Rectangle();
         // capture all screens in Windows
         foreach (Screen screen in Screen.AllScreens)
         {
            // increase the Rectangle to accommodate the bounds of all screens
            rect = Rectangle.Union(rect, screen.Bounds);
         }
         // create a new image that will store the capture
         Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
         using (Graphics g = Graphics.FromImage(bitmap))
         {
            // use GDI+ to copy the contents of the screen into the bitmap
            g.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
         }
         // bitmap now has the screen capture
