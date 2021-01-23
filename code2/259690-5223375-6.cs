    static Image ResizeImage(Image image, int desWidth, int desHeight)
    {
        int x, y, w, h;
        if (image.Height > image.Width)
        {
            w = (image.Width * desHeight) / image.Height;
            h = desHeight;
            x = (desWidth - w) / 2;
            y = 0;
        }
        else
        {
            w = desWidth;
            h = (image.Height * desWidth) / image.Width;
            x = 0;
            y = (desHeight - h) / 2;
        }
        var bmp = new Bitmap(desWidth, desHeight);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, x, y, w, h);
        }
        return bmp;
    }
