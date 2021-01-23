    XElement doc = XElement.Load("test.xml");
    var results = doc.Descendants("Value")
                     .Select( x => new { Id = x.Parent.Attribute("id").Value, 
                                         Value = x.Value });
    foreach(var result in results)
    {
        Console.WriteLine(string.Format("{0} : Value = {1}", 
                          result.Id, 
                          result.Value));
    }
