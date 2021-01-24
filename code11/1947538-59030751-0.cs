`
 [XmlRoot("test")]  
    public class Test {  
        int? propertyInt;  
        string propertyString;  
 
        [XmlAttribute("property-int")]  
        public int PropertyInt {  
            get { return (int)propertyInt; }  
            set { propertyInt = (int)value; }  
        }  
 
        public bool PropertyIntSpecified {  
            get { return propertyInt != null; }  
        }  
 
        [XmlAttribute("property-string")]  
        public string PropertyString {  
            get { return propertyString; }  
            set { propertyString = value; }  
        }  
    }  
 
    class Program {  
        static void Main(string[] args) {  
 
            XmlSerializer serializer = new XmlSerializer(typeof(Test));  
            serializer.Serialize(Console.Out, new Test() { PropertyInt = 3 });  //only int will be serialized  
            serializer.Serialize(Console.Out, new Test() { PropertyString = "abc" }); // only string will be serialized  
            serializer.Serialize(Console.Out, new Test() { PropertyInt = 3, PropertyString = "abc" }); // both - int and string will be serialized  
              
 
        }  
    } 
`
