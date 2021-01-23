    private static string GetFolderName(string path)
    {
        var end = -1;
        for (var i = path.Length; --i >= 0;)
        {
            var ch = path[i];
            if (ch == System.IO.Path.DirectorySeparatorChar ||
                ch == System.IO.Path.AltDirectorySeparatorChar ||
                ch == System.IO.Path.VolumeSeparatorChar)
            {
                if (end > 0)
                {
                    return path.Substring(i + 1, end - i - 1);
                }
                end = i;
            }
        }
        if (end > 0)
        {
            return path.Substring(0, end);
        }
        return path;
    }
