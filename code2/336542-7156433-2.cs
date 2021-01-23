    [XmlRoot("chart")]
    public class Chart
    {
        [XmlElement("series")]
        public Series Series { get; set; }
        [XmlArray("graphs")]
        [XmlArrayItem("graph")]
        public Graphs Graphs { get; set; }
    }
    public class Series
    {
        [XmlElement("value")]
        public List<SeriesValue> Values { get; set; }
    }
    public class Graphs : List<Graph>
    {
    }
    public class Graph
    {
        [XmlAttribute("gid")]
        public int Gid { get; set; }
        [XmlElement("value")]
        public List<GraphValue> Values { get; set; }
    }
    public class GraphValue
    {
        [XmlAttribute("xid")]
        public int Xid { get; set; }
        [XmlAttribute("color")]
        public String Color { get; set; }
        [XmlText]
        public int Value { get; set; }
    }
    public class SeriesValue
    {
        [XmlAttribute("xid")]
        public int Xid { get; set; }
        [XmlText]
        public String Text { get; set; }
    }
