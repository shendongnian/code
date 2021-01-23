    public static Bitmap TakeScreenshot(int x, int y, int height, int width)
    {
        Rectangle bounds = new Rectangle(0, 0, height, width);
        Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
        Graphics g = Graphics.FromImage(bitmap);
        g.CopyFromScreen(new Point(x, y), Point.Empty, bounds.Size);
    
        return bitmap;
    }
