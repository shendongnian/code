    using (Graphics g = Graphics.FromImage(bmp))
    {
        Rectangle crop = new Rectangle(222,222,55,55);
        g.SetClip(crop);
        g.Clear(Color.Transparent);
    }
    bmp.Save(somefilename, ImageFormat.Png);
