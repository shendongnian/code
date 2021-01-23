    public static XElement ElementOrDummy(this XElement parentElement, 
                                          XName name, 
                                          bool ignoreCase)
    {
        XElement existingElement = null;
        if (ignoreCase)
        {
            string sName = name.LocalName.ToLower();
            foreach (var child in parentElement.Elements())
            {
                if (child.Name.LocalName.ToLower() == sName)
                {
                    existingElement = child;
                    break;
                }
            }
        }
        else
            existingElement = parentElement.Element(name);
        if (existingElement == null)
            existingElement = new XElement(name, string.Empty);
        return existingElement;
    }
