    class One
    {
        public int OneField { get; set; }
    }
    class Two : One
    {
        [XmlElement("FirstField")]
        public new int OneField
        {
           get { return base.OneField; }
           set { base.OneField = value; }
        }
    }
