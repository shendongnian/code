    public class MyDic
    {
        ...
    
        [XmlElement(IsNullable = true)]
        public List<WebDefinition?> WebDefinitions;  //note the ? after your type.                    
    
        ...
    }
