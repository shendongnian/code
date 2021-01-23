    [XmlRoot("foo")]
    public class MyRoot {
        [XmlElement("bar")]
        public List<RemoteHost> Hosts {get;set;}
    }
