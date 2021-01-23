    static Regex ProfileRegex = new Regex(@"/public/(?<firstname>[a-zA-Z]+)-(?<lastname>[a-zA-Z]+)-(?<userid>[0-9]+)\.aspx$",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);
    
    void Application_BeginRequest(object sender, EventArgs e)
    {
        Match match = ProfileRegex.Match(Context.Request.FilePath);
        if( match != null )
        {
            Context.RewritePath((String.Format("~/public/userProfile.aspx?userId={0}",
                match.Groups["userid"]));
        }
    }
