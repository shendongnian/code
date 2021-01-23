    [XmlRoot("jobs")]
    public class jobs : List<job> { }
    public class job
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlElement("uses")]
        public List<uses> Files { get; set; }
    }
    public class uses
    {
        [XmlAttribute]
        public string file { get; set; }
        [XmlAttribute]
        public string link { get; set; }
    }
