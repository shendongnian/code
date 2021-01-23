    [XmlTypeAttribute]
    [XmlRootAttribute("Record")]
    public class RecordXmlConfiguration {
    [XmlElementAttribute("field")]
    public Field[] Fields { get; set; }
    }
    [XmlTypeAttribute]
    public class Field
    {
        [XmlAttributeAttribute("name")]
        public string Name {get;set;}
    }
