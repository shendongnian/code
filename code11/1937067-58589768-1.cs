    [Serializable, XmlRoot("Docs")]
    public class Root
    {
        [XmlElement("Doc")]
        public List<Doc> Docs { get; set; }
    }
    public class Doc
    {
        public string DocNumber { get; set; }
        [XmlElement("Anag")]
        public Anag Anags { get; set; }
    }
    public class Anag
    {
        [XmlElement("Name")]
        public string RagioneSociale { get; set; }
        [XmlElement("Address")]
        public string Indirizzo { get; set; }
        [XmlElement("ZipCode")]
        public string CAP { get; set; }
        [XmlElement("City")]
        public string Citta { get; set; }
        [XmlElement("Province")]
        public string Provincia { get; set; }
        [XmlElement("CountryCode")]
        public string CodiceNazione { get; set; }
        [XmlElement("PhoneNumber")]
        public string Telefono { get; set; }
        [XmlElement("CellularNumber")]
        public string Cellulare { get; set; }
        [XmlElement("EmailAddress")]
        public string Email { get; set; }
    }
