    public static void ScreenCapture(string filename, int width, int height)
    {
        var bounds = new Rectangle(0, 0, width, height);
        using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.CopyFromScreen(
                new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size
            );
            bitmap.Save(filename, ImageFormat.Jpeg);
        }
    }
