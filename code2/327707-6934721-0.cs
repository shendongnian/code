    List<string> test = new List<string>(); 
    test.Add("test's"); 
    test.Add("test"); 
    test.Add("test's more");
    string s = string.Join("','", test.Select(i => i.Replace("'", "''")).ToArray());
