    protected string GetPath(string path)
    {
        if (Path.IsPathRooted(path))
        {
            return path;
        }
        return Server.MapPath(path);
    }
