    var xml = XElement.Parse(@"<description>A plain <link ID=""1"">table</link> with a green hat on it.</description>");
    
    foreach (var node in xml.Nodes())
    {
    	Console.WriteLine("Type: " + node.NodeType);
    	Console.WriteLine("Object: " + node);
    	if (node.NodeType == XmlNodeType.Element)
    	{
    		var e = (XElement)node;
    		Console.WriteLine("Name: " + e.Name);
    		Console.WriteLine("Value: " + e.Value);
    	}
    	else if (node.NodeType == XmlNodeType.Text)
    	{
    		var t = (XText)node;
    		Console.WriteLine(t.Value);
    	}
    	Console.WriteLine();
    }
