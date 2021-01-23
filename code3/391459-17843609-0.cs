    List<string> phoneList = new List<string>();
    Regex rg = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");
    MatchCollection m = rg.Matches(html);
    foreach (Match g in m)
    {
    	if (g.Groups[0].Value.Length > 0)
    		phoneList.Add(g.Groups[0].Value);
    }
