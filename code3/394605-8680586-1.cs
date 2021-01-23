    using System.Xml.Linq;
    public class connection_state {
        public string state { get; set; }
        public connection_state(string xml) {
            this.state = XDocument.Parse(xml).Element("connection_state").Value;
        }
    }
