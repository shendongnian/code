    [XmlRoot("myroot")]
    public class MyRoot {
        [XmlElement("items")]
        public MyListWrapper Items {get;set;}
    }
    public class MyListWrapper {
        [XmlAttribute("attr1")]
        public string Attribute1 {get;set;}
        [XmlAttribute("attr2")]
        public string Attribute2 {get;set;}
        [XmlElement("item")]
        public List<MyItem> Items {get;set;}
    }
    public class MyItem {
        [XmlAttribute("id")]
        public int Id {get;set;}
    }
