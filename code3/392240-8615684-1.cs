    public class SomeClass 
    { 
       private double _someValue;
       
       [XmlIgnore()]
       public double SomeValue {
         get { return _someValue; }
         set {_someValue = value;}
       } 
    
       [XmlElement("SomeValue")]
       public double SomeValueSerialised
       {
          get { return _someValue * 10; }
          set { _someValue = value/10; }
       }
    } 
