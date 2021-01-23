    public static bool IsPathFullyQualified(string path)
    {
        var root = Path.GetPathRoot(path);
        return root.StartsWith(@"\\") || root.EndsWith(@"\");
    }
