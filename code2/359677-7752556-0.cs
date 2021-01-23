    public string getNavID(string Title)
    {
        var index = Title.IndexOf(". ");
        return Title.Substring(0, index -1).ToUpper();
    } 
