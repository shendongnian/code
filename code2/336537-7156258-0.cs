    [XmlRoot("chart")]
    public class BarChartSeriesEntity
    {
        [XmlElement("series")]
        public BarChartSeriesValue[] SeriesValues { get; set; }
        [XmlElement("graphs")]
        public BarChartGraphsValue[] GraphsValues { get; set; }
        public class BarChartSeriesValue
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
            [XmlAttribute("gid")]
            public string Gid { get; set; }
        }
        public class BarChartGraphValue
        {
            [XmlAttribute("xid")]
            public int Xid { get; set; }
            [XmlAttribute("color")]
            public int Color { get; set; }
            [XmlText]
            public int Value { get; set; }
        }
    }
