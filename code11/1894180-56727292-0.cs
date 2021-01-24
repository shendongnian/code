    Rectangle screenBounds = Screen.GetBounds(System.Drawing.Point.Empty);
    using (Bitmap bitmap = new Bitmap(screenBounds.Width, screenBounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
    {
        using (Graphics g = Graphics.FromImage(bitmap))
        {                       
            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
        }
        bitmap.Save("e:\\ScreenCopy.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
