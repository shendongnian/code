    using ...
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Xml.Serialization;
    [DataContract]
    [XmlSerializerFormat]
    public class root
    {
       public distance distance=new distance();
    }
   
    [DataContract]
    public class distance
    {
      [DataMember, XmlAttribute]
      public string units="m";
    
      [DataMember, XmlText]
      public int value=1000;
    }
