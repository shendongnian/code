    public static string RemoveInvalidFilePathCharacters(string filename, string replaceChar)
    {
        string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
        Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
        return r.Replace(filename, replaceChar);
    }
