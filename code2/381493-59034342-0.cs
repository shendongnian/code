    public static Graphics CreateGraphics(Image i)
    {
        Graphics g = Graphics.FromImage(i);
        g.CompositingMode = CompositingMode.SourceOver;
        g.CompositingQuality = CompositingQuality.HighSpeed;
        g.InterpolationMode = InterpolationMode.NearestNeighbor;
        g.SmoothingMode = SmoothingMode.HighSpeed;
        return g;
    }
