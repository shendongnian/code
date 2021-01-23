    var xDoc = XDocument.Load("AppManifest.xml");
    
    var students = 
        xDoc.Root.Elements("student")
        .Select(n =>
            new Student
            {
    	        Name = (string)n.Attribute("name"),
    	        Class = (string)n.Attribute("class"),
            })
        .ToList();
