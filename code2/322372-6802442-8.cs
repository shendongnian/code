    public static XElementExtensions
    {
    
    public void Set(this XElement self, string name, object value, bool isAttribute)
    {
        string sValue = value.ToString();
        XElement eValue = self.Element(name);
        XAttribute aValue = self.Attribute(name);
        if(null != eValue)
            eValue.ReplaceWith(new XElement(name, sValue));
        else if(null != aValue)
            aValue.ReplaceWith(new XAttribute(name, sValue));
        else if(isAttribute)
            self.Add(new XAttribute(name, sValue));
        else
            self.Add(new XElement(name, sValue));
    }
    }
