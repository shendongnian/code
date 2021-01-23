    string input = @"<p>Categories: 
            <a href=""/some/URL/That/I/dont/need"">Category1</a>  | 
            <a href=""/could/be/another/URL/That/I/dont/need"">Category2</a> 
    </p>";
    
    // LINQ to XML approach for well formed HTML
    var xml = XElement.Parse(input);
    var query = xml.Elements("a").Select(e => e.Value);
    foreach (var item in query)
    {
        Console.WriteLine(item);
    }
    
    // regex solution
    string pattern = @"Categories:(?:[^<]+<a[^>]+>([^<]+)</a>)+";
    
    Match m = Regex.Match(input, pattern);
    if (m.Success)
    {
        foreach (Capture c in m.Groups[1].Captures)
        {
            Console.WriteLine(c.Value);    
        }
    }
