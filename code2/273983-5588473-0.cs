    var list = new List<string>();
    foreach (XPathNavigator test in Service.Select("Testname"))
    {
    	list.Add(test.Value);
    }
    
    // If you need to get the values as an array
    
    string[] array = list.ToArray();
