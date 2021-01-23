    public class job
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        public List<uses> Files { get; set; }
    }
