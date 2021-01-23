    public class Two : One
    {
        private static XmlAttributeOverrides xmlOverrides;
        public static XmlAttributeOverrides XmlOverrides
        {
            get
            {
                if (xmlOverrides == null)
                {
                    xmlOverrides = new XmlAttributeOverrides();
                    var attr = new XmlAttributes();
                    attr.XmlElements.Add(new XmlElementAttribute("FirstField"));
                    xmlOverrides.Add(typeof(One), "OneField", attr);
                }
                return xmlOverrides;
            }
        }
        [XmlElement("SecondField")]
        public string TwoField;
        
    }
