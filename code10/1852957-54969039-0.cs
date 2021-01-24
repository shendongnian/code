    public static String GetUserNameInstagramUrl(String url)
    {
        Uri uri = new Uri(url);
        return uri.Segments.Last().TrimEnd('/');
    }
