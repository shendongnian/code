    string s1 = "HeLLo    wOrld!";
    string s2 = "Hello\n    WORLd!";
    
    string normalized1 = Regex.Replace(s1, @"\s", "");
    string normalized2 = Regex.Replace(s2, @"\s", "");
    
    bool stringEquals = String.Equals(
        normalized1, 
        normalized2, 
        StringComparison.OrdinalIgnoreCase);
    
    Console.WriteLine(stringEquals);
