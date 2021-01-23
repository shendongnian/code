    [XmlRoot("picture_list")]
    public class YourObject
    {   
         [XmlElement("picture")]
         public List<string> picture_list { get; set; }
    }
