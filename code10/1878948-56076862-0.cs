    [XmlRoot("DATA_SET ")]
    public sealed class MyRoot
    {
        [XmlElement("sampleSize")]
        public int SampleSize { get; set; }
        [XmlArrayItem("data")]
        public List<MyData> Data { get; set; }
    }
