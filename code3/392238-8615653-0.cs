    public class SomeClass:IXmlSerializable
    {
       public double SomeValue {get;set;}
     // implement here below read write as needed
     // Xml Serialization Infrastructure
    public void WriteXml (XmlWriter writer)
    {
        ...
    }
    public void ReadXml (XmlReader reader)
    {
        ...
    }
    public XmlSchema GetSchema()
    {
        return(null);
    }
    }
