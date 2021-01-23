    [XmlRoot("contacts")]
    public class Contacts{
        [XmlElement("contact")]
        public List<PendingContactDTO> contacts { get; set; } 
    }
