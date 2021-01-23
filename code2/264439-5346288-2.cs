    private List<string> reverseStringFormat(string template, string str)
    {
         //Handels regex special characters.
        template = Regex.Replace(template, @"[\\\^\$\.\|\?\*\+\(\)]", m => "\\" 
         + m.Value);
        string pattern = "^" + Regex.Replace(template, @"\{[0-9]+\}", "(.*?)") + "$";
            
        Regex r = new Regex(pattern);
        Match m = r.Match(str);
    
        List<string> ret = new List<string>();
    
        for (int i = 1; i < m.Groups.Count; i++)
        {
            ret.Add(m.Groups[i].Value);
        }
    
        return ret;
    }
