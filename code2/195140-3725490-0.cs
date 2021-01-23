    const string pattern = @"(?<objectName>\w+)\s(?<attrName>\w+)\.(?<attrType>\w+)";
    
    string[] lines = File.ReadAllLines(@"e:\a.txt");
    var items = from line in lines
                select new
                {
                    objectName = Regex.Match(line, pattern).Groups["objectName"].Value,
                    attrName = Regex.Match(line, pattern).Groups["attrName"].Value,
                    attrType = Regex.Match(line, pattern).Groups["attrType"].Value
                };
    
    foreach (var item in items.ToList())
    {
        Console.WriteLine("ObjectName = {0}, AttributeName = {1}, Attribute Type = {2}",
            item.objectName, item.attrName, item.attrType);
    }
