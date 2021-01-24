    class ToSerialize
    {
        [XmlElement("A", typeof(A))]
        [XmlElement("B", typeof(B))]
        public object AorB { get; set; }
    }
You could create a common base class instead of using object to be more specific.
