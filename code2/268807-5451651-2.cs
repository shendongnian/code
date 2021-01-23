    if (xml.Element(parent).Element(node) != null)  // <--- No .Value
    {
        xml.Element(parent).Element(node).Value = newVal;
    }
    else
    {
        xml.Element(parent).Add(new XElement(node, newVal)); 
    }
