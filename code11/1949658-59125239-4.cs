    [XmlType("Event")]
    public class Event
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("start")]
        public DateTime Start { get; set; }
        [XmlElement("end")]
        public DateTime End { get; set; }
        [XmlArray("contacts")]
        public virtual List<Contact> Contacts { get; set; }
    }
    [XmlType("contact")]
    public class Contact
    {
        [XmlElement("id")]
        public int Id { get; set; }
        
        [XmlElement("name")]
        public string Name { get; set; }
    }
