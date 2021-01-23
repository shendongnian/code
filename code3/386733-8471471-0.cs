    var xml = XElement.Load(@"path\to\your\xml\file");
    
    var elements = xml.Elements("Control").Where(e => e.Attribute("ToValidate") != null);
    
    foreach(var element in elements)
    {
        var validateAttribute = element.Attribute("ToValidate").Value;
        if (validateAttribute == "0")
        {
            // something if invalid
        }
        else 
        {
            // something if valid
        }
    }
