    [XmlType("device_list")]
    [Serializable]
    public class DeviceList {
        [XmlAttribute]
        public string type { get; set; }
        [XmlElement( "item" )]
        public ListItem[] items { get; set; }
    }
