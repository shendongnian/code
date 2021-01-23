    public Dictionary<String, Foo> Merge(XElement element1, XElement element2)
    {
        IEnumerable<Foo> firstFoos = GetXmlData(element1); // parse 1st set from XML
        IEnumerable<Foo> secondFoos = GetXmlData(element2); // parse 2nd set from XML
        var result = firstFoos.Union(secondFoos).ToDictionary(k=>k.Name, v=>v);
    
        return result;
    }
    public class Foo
    {
        public String Name { get; }
        // other Properties and Methods
        // .
        // .
        // .
        public override Boolean Equals(Object obj)
        {
            if (obj is Foo)
            {
                return this.Name == ((Foo)obj).Name;            
            }
            return false;
        }
    }
