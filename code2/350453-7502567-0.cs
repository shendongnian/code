    [CollectionDataContract(Name = "Options", ItemName = "Option")]
    public class OptionItemCollection : List<OptionItem>
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        public OptionItemCollection()
        {
        }
        public OptionItemCollection(IEnumerable<OptionItem> items)
            : base(items)
        {
        }
    }
    // note, remove attributes
    public class OptionItem : IXmlSerializable
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Value", Value);
            writer.WriteElementString("Text", Text);
        }
        public void ReadXml(XmlReader reader)
        {
            // implement if necessary
            throw new NotImplementedException();
        }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
    }
