    [XmlRoot("Request")]
    public class SampleClass
    {
        public string Name { get; set; }
        public string ID { get; set; }
        [XmlElement("Type")]
        public SubClass SC { get; set; }
        public string SentTime { get; set; }
        public class SubClass
        {
            public string ItemId { get; set; }
            public string ShopId { get; set; }
            [XmlElement("MessageXml")]
            public Sub2Class SC2 { get; set; }
            public class Sub2Class
            {
                public string ChildMessage { get; set; }
            }
        }
    }
