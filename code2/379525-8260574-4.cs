    [XmlTypeAttribute]
    [XmlRootAttribute("Record")]
    public class RecordXmlConfiguration {
    [XmlElementAttribute("id")]
    public long? Id { get; set; }
    [XmlElementAttribute("user_id")]
    public long? UserId { get; set; }
    [XmlElementAttribute("updated")]
    public DateTime? Updated { get; set; }
    }
