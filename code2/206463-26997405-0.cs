    // value passed as "o'clock"
    public async Task AddString(string value)
    {
        // Escape ' with '' and UrlEncode value
        value = HttpUtility.UrlEncode(value.Replace("'", "''"));
        string url = String.Format("AddString?value='{0}'", value);
        // No need to UrlEncode url here as dynamic content has already been escaped 
        // Execute .....
    }
    [WebGet]
    public void AddString(string value) 
    {
        // here value will be "o'clock"
    }
