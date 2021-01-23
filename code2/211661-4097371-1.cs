    public class Object{
    static XDocument doc;
    static LoadXml()
    {
        doc = XDocument.Load(@"xmldocument.xml");
    }
      public int ValueA{
        get
        set;
      }
    
      public string ValueB{
        get;set;
      }
    
      public int Description{
        get{
          return (string)doc.Elements("test").Single(t => t.Element(ValueB).Value);
      }
    }
