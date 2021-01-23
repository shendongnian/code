    private static bool IsSubpathOf(string path, string subpath)
    {
        return (subpath.Equals(path, StringComparison.OrdinalIgnoreCase) ||
                subpath.StartsWith(path + @"\", StringComparison.OrdinalIgnoreCase));
    }
