    using System.Text.RegularExpressions;
    
    List<string> muList = new List<string>(new string[] { "abc001", "abc002", "cdef001" });//simulate your real list    
    string pattern = @"^(*.)\d*$";
    
    Regex regex = new Regex(pattern);
    
    List<string> matchesStrings = new List<string>();
    
    foreach (string item in myList)
    {
        var match = regex.Match(item);
    
        if (match.Groups.Count > 1)
        {
            matchesString.Add(match.Groups[1].Value);
        }
    }
