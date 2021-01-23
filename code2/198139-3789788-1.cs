    private const string tempUserBlock = "%%%COMPRESS~USER{0}~{1}%%%"; 
    string html = "some html"; 
    int p = 0; 
    var userBlock = new List<string>(); 
     
    MatchCollection matcher = preservePattern.Matches(html); 
    StringBuilder sb = new StringBuilder(); 
    int last = 0;
    foreach (Match m in matcher)
    {
        string match = m.Groups[0].Value; 
        if(match.Trim().Length > 0) { 
            userBlock.Add(match); 
            sb.Append(html.Substring(last, m.Index - last));
            sb.Append(m.Result(string.Format(tempUserBlock, p, index++)));
        }
        last = m.Index + m.Length;
    }
    sb.Append(html.Substring(last));
    html = sb.ToString(); 
