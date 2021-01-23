    public static DateTime GetBuildDate()
    {
        UriBuilder uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
        return File.GetLastWriteTime(
            Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path))
            );
    }
