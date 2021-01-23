    [Serializable]
    [XmlRoot("unit")]
    public class Unit
    {
        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public Unit[] Units { get; set; }
        [XmlElement("unitName")]
        public string Name { get; set; }
    }
