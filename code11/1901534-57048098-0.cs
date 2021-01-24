    [XmlRoot("space", Namespace = "http://www.collegenet.com/r25")]
    public class Space
    {
        public long space_id { get; set; }
        public string space_name { get; set; }
        public string formal_name { get; set; }
        public long partition_id { get; set; }
        public DateTime last_mod { get; set; }
    }
