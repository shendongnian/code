    string originalString = "\"24.09.2019\",\"545\",\"878\",\"5\"";
    var regex = new Regex("\"[0-9\\.]+\"");
    var matches = regex.Matches(originalString);
    
    string result = string.Join(',', Enumerable.Range(1, matches.Count).Select(n => $"\"{{{n}}}\""));
