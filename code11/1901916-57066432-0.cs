    public static string GetToken(string path, bool isLog = false)
    {
        if (File.Exists(path))
        {
            string text = string.Empty;
            // set text...
            return text;
        }
        else
        {
            return string.Empty // <-- or return something more meaningful
        }
    }
