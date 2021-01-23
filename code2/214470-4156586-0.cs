    public interface BaseBarA<T> where T : BaseThing{
      protected internal abstract T DataFromXmlElements(IEnumerable<XmlNode> nodes);  
    }
    public interface BaseBarB<T> where T : BaseThing{
      T DataFromXmlElements(IEnumerable<XmlNode> nodes, string[] fieldNames);  
    }
