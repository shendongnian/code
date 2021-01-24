[XmlRoot(ElementName = "Invoice", Namespace = "", IsNullable = false)]
    public class Invoice
    {
        [XmlArrayItem(ElementName = "Item")]
        public virtual List<Item> Items { get; set; }
    }
[XmlRoot(ElementName = "Item")]
    public class Item
    {
        [XmlAttribute(AttributeName = "Line")]
        public virtual int Line { get; set; }
        [XmlAttribute(AttributeName = "MatNum")]
        public virtual string MatNum { get; set; }
    }
