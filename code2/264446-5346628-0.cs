    [Serializable]
    [XmlType(AnonymousType=true)]
    [XmlRoot(IsNullable=false)]
    public partial class Table {
        
        [XmlElement("Route")]
        public TableRoute[] Items { get; set; }
        }
    }
    [Serializable]
    [XmlType(AnonymousType=true)]
    public partial class TableRoute {
        
        [XmlElement]
        public TableRouteItem[] Name { get; set; }
        
        [XmlElement]
        public TableRouteItem[] City { get; set; }
        
        [XmlAttribute]
        public string No { get; set; }
    }
    [Serializable]
    [XmlType(AnonymousType=true)]
    public partial class TableRouteItem {
        
        [XmlAttribute]
        public string No { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
