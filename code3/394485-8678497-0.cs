    // .NET 4.0
    if(string.IsNullOrWhitespace(Request.QueryString["aspxerrorpath"]))
    {
     // not there!
    }
    // .NET < 4.0
    if(string.IsNullOrEmpty(Request.QueryString["aspxerrorpath"]))
    {
     // not there!
    }
