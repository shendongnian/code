    public static string MakeFilename(this DateTime dt)
    {
        return dt.ToString("yyyyMMdd-HHmmss");
    }
}
