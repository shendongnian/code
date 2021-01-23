    public class MyClass
    {
       [XmlAttribute("MyAttribute")] public string str4 { get; set; } //This is a XML-Attribute, Order not applicable
       [XmlIgnore] public string str1 { get; set; } //This is a [XmlIgnore], Order not applicable
       [XmlElement(Order = 5)] public string str2 { get; set; } // Standard property with Order    
       [XmlElement(Order = 2)] public string str3 { get; set; } // Standard property with Order    
       [XmlElement(Order = 1)] public List<MyList> ListElms = new List<MyList> //List collection with Order
       {
          new ListElm {str1 = "xxx", str2 ="yyy", str3 ="zzz"} ,
          new ListElm {str1 = "xxx", str2 ="yyy", str3 ="zzz"}
       };
     
       public class MyList
       {
          [XmlElement(Order = 3)] public string str1 { get; set; } // Order can be assigned, but not mandatory 
          [XmlElement(Order = 2)] public string str2 { get; set; } // Order can be assigned, but not mandatory
          [XmlElement(Order = 1)] public string str3 { get; set; } // Order can be assigned, but not mandatory
       }
    }
