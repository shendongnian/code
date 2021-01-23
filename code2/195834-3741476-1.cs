    var doc = XDocument.Load(source);
    var ns = doc.Root.GetDefaultNamespace();
    
    var topCube = doc.Root.Element(ns+"Cube");
    var timeCube = topCube.Element(ns+"Cube");
    
    string time = timeCube.Attribute("time").Value;
    
    var cubes = from c in timeCube.Elements()
                select new 
                {  Key = c.Attribute("currency").Value, 
                   Value = decimal.Parse(c.Attribute("rate").Value, CultureInfo.InvariantCulture) 
                };
