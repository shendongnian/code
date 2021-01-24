    [XmlRoot("message")]
    public class MessageBody
    {
        [XmlElement("Checks")]
        public Checks Checks { get; set; }
    }
    public class Checks
    {
        [XmlAttribute]
        public string type { get; set; }
        [XmlElement("Checks")]
        public List<Check> Checks { get; set; }
    }
    public class Check
    {
        [XmlElement("C_CHECK_NUMBER")]
        public string CheckNumber { get; set; }
        [XmlElement("C_CHECK_AMOUNT")]
        public decimal Amount { get; set; }
    }
