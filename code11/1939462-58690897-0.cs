        [XmlRoot("MyList")]
        public class MyListXml
        {
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Date")]
            public string Date { get; set; }
            [XmlElement("User")]
            public List<UserXml> usersXml { get; set; }
        }
        public class UserXml
        {
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
        }
