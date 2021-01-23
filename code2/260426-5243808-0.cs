    public class childrenNode
    {
       [XmlElement("myClass1", typeof(myClass1))]
       [XmlElement("myClass2", typeof(myClass2))]
       public BaseNode[] nodes { get; set; }
    }
    public class BaseNode
    {
      
    }
    public class myClass1: BaseNode
    {
    }
    
    public class myClass2: BaseNode
    {
    }
