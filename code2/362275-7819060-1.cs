        [Serializable]
        [XmlRoot("acc")]
        public class Account
        {
            [XmlElement("Account")]
            public string Account { get; set; }
            [XmlElement("Partner")]
            public int Partner { get; set; }
            [XmlElement("CITY")]
            public string City { get; set; }
        }
