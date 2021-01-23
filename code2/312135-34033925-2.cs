    public string AddQuotesIfRequired(string path)
    {
        return !string.IsNullOrEmpty(path) ? 
            path.Contains(" ") ? "\"" + path + "\"" : path
            : string.Empty;                                
    }
