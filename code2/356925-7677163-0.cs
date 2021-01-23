    using (var tempImage = Image.FromFile(f))
    {
        Bitmap bmp = new Bitmap(thumbnailWidth, thumbnailHeight);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.DrawImage(tempImage, new Rectangle(0, 0, bmp.Width, bmp.Height);
        }
        t.Images.Add(bmp);
    }
