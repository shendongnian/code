    [XmlRoot("Family")]
    public class FamilyBlock
    {
        [XmlElement("NAME")]
        public string[] NAME { get; set; }
        [XmlElement("AGE")]
        public int[] AGE { get; set; }
        [XmlElement("DOB")]
        public DateTime?[] DOB { get; set; }
    }
