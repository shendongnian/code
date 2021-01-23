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
        
    public T Get<T>(this XElement self, string name, T @default, bool? isAttribute)
    {
        XElement eValue = self.Element(name);
        XAttribute aValue = self.Attribute(name);
        if(null == isAttribute) // try both
        {
             if(null != eValue) return (T)eValue; // T has to be able to convert strings (I believe)
             if(null != aValue) return (T)aValue;
             return @default;
        }
        if(isAttribute && null != aValue) return (T)aValue;
        if(!isAttribute && null != eValue) return (T)eValue; 
        return @default;
    }
    }
