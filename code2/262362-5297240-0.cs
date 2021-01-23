    Rectangle region = new Rectangle(0, 0, SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
    using (Bitmap bitmap = new Bitmap(region.Width, region.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
    using (Graphics bitmapGraphics = Graphics.FromImage(bitmap))
    {
    bitmapGraphics.CopyFromScreen(region.Left, region.Top, 0, 0, region.Size);
    bitmap.Save("location");
    }
