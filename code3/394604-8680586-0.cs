    public class connection_state {
        public string state { get; set; }
        public connection_state(string xml) {
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            this.state = x.SelectSingleNode("connection_state").InnerText;
        }
    }
