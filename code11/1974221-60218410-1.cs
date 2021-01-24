    public static string GetARG(Color c)
    {
        return string.Format("{0},{1},{2}", c.A, c.R, c.G);
    }
    public static string GetARGHex(Color c)
    {
        return string.Format("{0:X2}{1:X2}{2:X2}", c.A, c.R, c.G);
    }
