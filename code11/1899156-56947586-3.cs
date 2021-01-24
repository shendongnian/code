    string file = yourImageFileName;
    Bitmap bmp = GetClone(file);
    using (Graphics g = Graphics.FromImage(bmp))
    {
        // draw what you want..
        g.DrawRectangle(Pens.Red, 11, 11, 199, 199);
    }
    bmp.Save(file, ImageFormat.Png);  // use your own format etc..
