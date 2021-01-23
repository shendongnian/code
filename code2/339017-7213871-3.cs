    using System.Text.RegularExpressions;
    
    //simulate your real list 
    List<string> myList = new List<string>(new string[] { "abc001", "abc002", "cdef001" });   
    string pattern = @"^(\D*)\d*$";\\  \D* any non digit characters, and \d* means followed by digits
    
    Regex regex = new Regex(pattern);
    
    HashSet<string> matchesStrings = new HashSet<string>();
    
    foreach (string item in myList)
    {
        var match = regex.Match(item);
    
        if (match.Groups.Count > 1)
        {
            matchesString.Add(match.Groups[1].Value);
        }
    }
