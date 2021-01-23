    using System.Text.RegularExpressions;
    
    Regex re = new System.Text.RegularExpressions.Regex(searchText.Text.ToString(),RegexOptions.None);
    MatchCollection mc = re.Matches(frm1TB.Text.ToString());
    foreach (var ma in mc)
    {
     
    //do what you want
    }
