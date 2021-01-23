    public class SomeObject
    {
        public List<Layer> Layers { get; set; }
    }
    public class Layer
    {
        [XmlAttribute]
        public int Id { get; set; }
    
        [XmlElement("RowInfo")]
        public List<RowInfo> RowInfos { get; set; }
    }
    public class RowInfo
    {
        [XmlText]
        public string Info { get; set; } // you'll need to parse the list of ints manually
    }
