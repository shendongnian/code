    [XmlTypeAttribute]
    [XmlRootAttribute("Record")]
    public class RecordXmlConfiguration {
    [XmlAttributeAttribute("id")]
    public long? Id { get; set; }
    [XmlAttributeAttribute("user_id")]
    public long? UserId { get; set; }
    [XmlAttributeAttribute("updated")]
    public DateTime? Updated { get; set; }
    }
