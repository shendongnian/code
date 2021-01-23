    public Dictionary<string, string> ForumVars = null;
    public WebWizForumVersion(XmlReader Data)
    {
        ForumVars = new Dictionary<string, string>();
        ForumVars.Add("Software", GetValue("Software"));
        ForumVars.Add("Version", GetValue("Version"));
        ForumVars.Add("APIVersion", GetValue("APIVersion"));
    }
    protected string GetValue(string key)
    {
        Data.ReadToFollowing(key);
        return Data.ReadElementContentAsString();
    }
