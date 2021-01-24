    XmlRoot("readyGrid")]
    public class Root
    {
        [XmlElement("gridRows")]
        public List<GridRows> GridRows { get; set; }
    }
    public class GridRows
    {
        [XmlElement("gridRow")]
        public List<GridRow> GridRow { get; set; }
    }
    public class GridRow
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("gridCol")]
        public List<GridCol> GridCol { get; set; }
    }
    public class GridCol
    {
        [XmlAttribute("id")]
        public int idColumn { get; set; }
        
        [XmlText]
        public string Content { get; set; }
    }
