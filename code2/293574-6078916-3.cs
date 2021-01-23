    class AtomXmlTextWriter : XmlTextWriter
    {
    	internal const string Atom10XmlNs = "http://www.w3.org/2005/Atom";
    	internal const string Atom10XmlNsPrefix = "a";
    	
    	public AtomXmlTextWriter(String filename, Encoding encoding)
    		: base(filename, encoding)
    	{
    	}
    
    	public override void WriteStartElement(string prefix, string localName, string ns)
    	{
    		base.WriteStartElement(GetAtomPrefix(ns), localName, ns);
    	}
    
    	public override void WriteStartAttribute(string prefix, string localName, string ns)
    	{
    		base.WriteStartAttribute(GetAtomPrefix(ns), localName, ns);
    	}
    
    	internal string GetAtomPrefix(string ns)
    	{
    		string prefix = string.Empty;
    
    		if ((ns != null) && (ns.Equals(Atom10XmlNs)))
    			prefix = Atom10XmlNsPrefix;
    
    		return prefix;
    	}
    }
