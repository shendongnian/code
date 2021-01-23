    XNamespace osNs = "http://xml.com"; // Like Jon said, you haven't included the namespace url
    
    XElement taxElement = XElement.Load("path/to/your/xml/file");
    
    
    foreach(var cat in taxElement.Decendents(osNs + "cat"))
    {
    	Console.WriteLine(cat.Attribute("id").Value);
    	
    	foreach(var subcat in cat.Decendents(osNs + "subcat"))
    	{
    		Console.WriteLine(subcat.Attribute("id").Value);
    		
    		foreach(var t in subcat.Decendents(osNs + "t"))
    		{
    			Console.WriteLine(t.Attribute("id").Value);
    			
    			foreach(var cut in t.Decendents(osNs + "cut"))
    			{
    				Console.WriteLine(cut.Attribute("id").Value);
    				Console.WriteLine(cut.Attribute("name").Value);
    				Console.WriteLine(cut.Attribute("cutURL").Value);
    			}
    		}
    	}
    }
