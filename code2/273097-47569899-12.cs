    public static bool IsFullPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || path.IndexOfAny(Path.GetInvalidPathChars()) != -1 || !Path.IsPathRooted(path))
            return false;
        
        string pathRoot = Path.GetPathRoot(path);
        if (pathRoot.Length <= 2 && pathRoot != "/") // Accepts X:\ and \\UNC\PATH, rejects empty string, \ and X:, but accepts / to support Linux
            return false;
        if (pathRoot[0] != '\\' || pathRoot[1] != '\\')
            return true; // Rooted and not a UNC path
        return pathRoot.Trim('\\').IndexOf('\\') != -1; // A UNC server name without a share name (e.g "\\NAME" or "\\NAME\") is invalid
    }
