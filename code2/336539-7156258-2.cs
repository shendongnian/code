    [XmlRoot("chart")]
    public class BarChartSeriesEntity
    {
        [XmlElement("series")]
        public BarChartSeriesValue[] SeriesValues { get; set; }
        [XmlElement("graphs")]
        public BarChartGraphsValue[] GraphsValues { get; set; }
        public class BarChartSeriesValue
        {
            [XmlElement("value")]
            public SeriesValueEntity[] Values { get; set; }
        }
        public class SeriesValueEntity
        {
            [XmlAttribute("xid")]
            public string Xid { get; set; }
            [XmlText]
            public string Value { get; set; }
        }
        public class BarChartGraphsValue
        {
            [XmlElement("graph")]
            public BarChartGraphValue[] Graphs { get; set; }
        }
        public class BarChartGraphValue
        {
            [XmlAttribute("gid")]
            public string Gid { get; set; }
            [XmlElement("value")]
            public GraphValueEntity[] Values { get; set; }
        }
        public class GraphValueEntity
        {
            [XmlAttribute("xid")]
            public string Xid { get; set; }
            [XmlAttribute("color")]
            public string Color { get; set; }
            [XmlText]
            public string Value { get; set; }
        }
    }
