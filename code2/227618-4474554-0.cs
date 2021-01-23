    private static string GetMiddleSegment(string URL)
    {
        // you should probably use a library function for this kind of thing
        int first = URL.IndexOf(@"/");
        int last = URL.LastIndexOf(@"/");
        return URL.Substring(first + 1, last - first - 1); // this is correct, right?
    }
    
    private static string SeparateWords(string camelCase)
    {
        return Regex.Replace(camelCase, "([a-z])([A-Z])", "$1 $2");
    }
    
    private static string Uppercase(string name)
    {
        return char.ToUpper(name[0]) + name.Substring(1);
    }
    
    // ...
    
    string incomingURL = Request.QueryString["ReturnURL"].ToString();
    string nameSegment = GetMiddleSegment(incomingURL);
    string displayName = Uppercase(SeparateWords(nameSegment));
    lblPortalName.Text = displayName;
