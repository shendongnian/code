        Rectangle rect = new Rectangle(625, 778, 475, 22);
        Bitmap bitmap = Bitmap.FromFile(@"C:\m.png") as Bitmap;
        Bitmap croppedBitmap = new Bitmap(bitmap, rect.Width, rect.Height);
        croppedBitmap.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
        using (Graphics gfx = Graphics.FromImage(croppedBitmap))
        {
            gfx.DrawImage(bitmap, 0, 0, rect, GraphicsUnit.Pixel);
        }
        croppedBitmap.Save(@"C:\m-1.png", System.Drawing.Imaging.ImageFormat.Png);
