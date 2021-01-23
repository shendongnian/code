    Image i = Image.FromFile(fileName); // This is 300x300
    Bitmap b = new Bitmap(500, 500);
    using(Graphics g = Graphics.FromImage(b))
    {
        g.DrawImage(i, 0, 0, 500, 500);
    }
