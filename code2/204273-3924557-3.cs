    public static StreamReader OpenText(string path)
    {
        if (path == null)
        {
            throw new ArgumentNullException("path");
        }
        return new StreamReader(path);
    }
