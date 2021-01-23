    public static int ToBgr(this Color color)
    {
        return ToBgr(color.R, color.G, color.B);
    }
    public static int ToBgr(int r, int g, int b)
    {
        //  & 0xFFFFFF -> Strip away alpha channel which powerpoint doesn't like
        return Color.FromArgb(b, g, r).ToArgb() & 0xFFFFFF;
    }
