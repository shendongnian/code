    public static int ToRGB(Color color)
    {
        //  & 0xFFFFFF -> Strip away alpha channel which powerpoint doesn't like
        return color.ToArgb() & 0xFFFFFF;
    }
    public static int ToRGB(int R, int G, int B)
    {
        return ToRGB(Color.FromArgb(R, G, B));
    }
    public static int ToBGR(Color color)
    {
        return ToBGR(color.R, color.G, color.B);
    }
    public static int ToBGR(int R, int G, int B)
    {
        //  & 0xFFFFFF -> Strip away alpha channel which powerpoint doesn't like
        return Color.FromArgb(B, G, R).ToArgb() & 0xFFFFFF;
    }
