    public class YourObject
    {
         [XmlArray("picture_list")]  
         [XmlArrayItem("picture")]
         public List<string> picture_list { get; set; }
    }
