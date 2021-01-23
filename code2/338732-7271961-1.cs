    Bitmap bitmap = new Bitmap(image1.Width + image2.Width, Math.Max(image1.Height, image2.Height));
    using (Graphics g = Graphics.FromImage(bitmap))
    {
        g.DrawImage(image1, 0, 0);
        g.DrawImage(image2, image1.Width, 0);
    }
