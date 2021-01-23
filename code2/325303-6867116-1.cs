    public class SerializableNodeTreeDouble : SerializableNodeTree
    {
       public new XDocument Document
       {
         get;         
         set;
       }
       ...
    }
    public void TestMethod()
    {
       SerializableNodeTreeDouble testDouble = new SerializableNodeTreeDouble();
       testDouble.XDocument = xdoc; // your xdoc
       
       ...
    }
