    foreach (XmlElement element in includeNodeList.OfType<XmlElement>())
    {
        if (!string.IsNullOrEmpty(element.GetAttribute("href")))
        {                  
            element.SetAttribute("href", "...");
        }
    }
