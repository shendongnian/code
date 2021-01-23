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
    public string GetString(this XElement self, string name, string @default, bool? isAttribute)
    {
        XAttribute aValue = self.Attribute(name);
        XElement eValue = self.Element(name);
        if(null == isAttribute) // try both
        {
            if(null != aValue) return (string)aValue;
            if(null != eValue) return (string)eValue;
            return @default;
        }
        if(isAttribute && null != aValue)
            return (string)aValue;
        if(!isAttribute && null != eValue)
            return (string)eValue);
        return @default;
    }
    public int GetInt(this XElement self, string name, int @default, bool? isAttribute)
    {
        return Convert
            .ToInt32(GetString(self, name, null, isAttribute) ?? @default.ToString());
    }
    }
