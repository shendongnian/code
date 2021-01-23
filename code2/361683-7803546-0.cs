    [Serializable]
    [XmlRoot("unit")]
    public class Unit
    {
        [XmlArray("units")]
        [XmlArrayItem("unit")]
        public Unit[] Units { get; set; }
        [XmlAttribute("unitName")]
        public string Name { get; set; }
    }
