    [Serializable]
    public class Settings
    {
        [XmlElement]
        public int Version { get; set; }
        [XmlElement]
        public string Name { get; set; }
        // more settings
    }
