    System.Collections.Generic.Dictionary<string, string> hashTable = new System.Collections.Generic.Dictionary<string, string>();
    
    string myString = "Type=\"Category\" Position=\"Top\" Child=\"3\"";
    string pattern = @"([A-Za-z0-9]+)(\s*)(=)(\s*)("")([^""]*)("")";
    System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(myString, pattern);
    foreach (System.Text.RegularExpressions.Match m in matches)
    {
        string key = m.Groups[1].Value;    // ([A-Za-z0-9]+)
        string value = m.Groups[6].Value;    // ([^""]*)
        hashTable[key] = value;
    }
