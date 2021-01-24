    var xDoc = XDocument.Parse(xml);
    var nodes = xDoc.Descendants().Where(x=>!x.Elements().Any()); // Select all leaf nodes
    foreach(var node in nodes)
    {
    	node.Value = node.Value.Trim(); // Remove leading and trailing whitespaces
    }
    
    var result = xDoc.ToString();
