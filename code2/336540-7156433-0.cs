    [XmlRoot("chart")]
    public class Chart
    {
        [XmlElement("series")]
        public Series Series { get; set; }
        [XmlArray("graphs")]
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
