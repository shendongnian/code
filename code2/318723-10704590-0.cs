    public abstract class BaseClass
    {
    
    }
    
    public class FirstChild:BaseClass
    {
    
    }
    
    public class SecondChild:BaseClass
    {
    
    }
    
    public class Request
    {
            [XmlArrayItem(Type = typeof(FirstChild), ElementName = "FirstChild")]
            [XmlArrayItem(Type = typeof(SecondChild), ElementName = "SecondChild")] 
            public BaseClass[] Child {get;set;}
    
    }
