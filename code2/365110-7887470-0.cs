    using System.Text.RegularExpressions;
    
    public static string GetPublicationID(string id)
    {
        Match m = RegEx.Match(@"tcm:([\d]+-[\d]{1})", id);
        if(m.Success)
            return string.Format("tcm:0-{0}", m.Groups[1].Captures[0].Value.ToString());
        else
            return string.Empty;
    }
