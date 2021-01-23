    [XmlRoot]
    public class MyClass
    {
        [XmlElement]
        public string MyDateTime { get; set; }
        [XmlIgnore]
        public DateTime DT
        {
            get { /* return DateTime from MyDateTime */ }
            set { MyDateTime = value.ToString( /* use formatting */); } // ex. ToString("yyyy, MMMM dd : hh:mm")
        }
        [XmlElement]
        public MySubClass TheSubClass { get; set; }
    }
