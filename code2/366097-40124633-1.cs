    private static string GetRootFolder(string path)
    {
        var root = Path.GetPathRoot(path);
        while (true)
        {
            var temp = Path.GetDirectoryName(path);
            if (temp != null && temp.Equals(root))
                break;
            path = temp;
        }
        return path;
    }
