    [XmlRoot("ObjectSummary")]
    public class Summary
    {
         public string Name {get;set;}
         [XmlIgnore]
         public bool IsValid {get;set;}
         [XmlElement("IsValid")]
         public string IsValidXml {get{ ...};set{...};}
         
    }
