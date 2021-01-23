    static string GetRootFolder(string path)
    {
        while (true)
        {
            string temp = Path.GetDirectoryName(path);
            if (String.IsNullOrEmpty(temp))
                break;
            path = temp;
        }
        return path;
    }
