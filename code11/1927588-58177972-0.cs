    [XmlRoot(ElementName = "HomeKey")]
    public class HomeKey
    {
       [XmlAttribute(AttributeName = "KeyId")]
       public string KeyId { get; set; }
       [XmlText]
       public string Text { get; set; }
    }
    
    [XmlRoot(ElementName = "Script")]
    public class ScriptV2
    {
       [XmlElement(ElementName = "Name")]
       public string Name { get; set; }
       [XmlElement(ElementName = "HomeKey")]
       public HomeKey HomeKey { get; set; }
    }
