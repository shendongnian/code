    private static Image PasteImage(Image startimage)
    {
        int width = Math.Max(900, 400 + startimage.Width);
        int height = Math.Max(900, 450 + startimage.Height);
        var bmp = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(bmp)) {
            g.DrawImage(startimage, 400, 450);
        }
        return bmp;
    }
