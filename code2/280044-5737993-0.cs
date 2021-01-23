    using System.Net; // WebClient
    using System.Text.RegularExpressions; // Regex
    
    WebClient wc = new WebClient();
    string html = wc.DownloadString("<your url goes here>");
    Regex regex = new Regex("<span id=\"yfs_l10_\\^gsptse\">([0-9\\.,]*)");
    MatchCollection matches = regex.Matches(html);
    if (matches.Count > 0 && matches[0].Groups.Count > 0)
    {
        // group 0 is entire string, group 1 is value matched in parenthesis
        string value = matches[0].Groups[1].Value; 
    }
