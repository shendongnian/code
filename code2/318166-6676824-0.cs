    public IList<string> FilterPathList(IList<string> paths, string basePath)
    {
        var result = from s in paths.AsParallel()
                     where s.StartWith(basePath)
                     select s;
        return result.ToList();
    }
