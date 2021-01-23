    public class Route
    {
        [XmlAttribute]
        public string No 
        { 
            get { return "1108"; } 
        }
        **[XMLAttributeProperty("No", "60")]**
        public string Name 
        { 
            get { return _Name; } 
            set { _Name = value; } 
        }
        **[XMLAttributeProperty("No", "70")]**
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
    }
