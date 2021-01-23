    public class Person
    {
        private string _name;
        [XmlIgnore]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                ThePersonName = new PersonName()
                                    {
                                        Name = FullName,
                                        NiceName = _name
                                    };
            }
        }
        [XmlElement(ElementName = "Name")]
        public PersonName ThePersonName { get; set; }
        public string FullName { get; set; }
    }
    public class PersonName
    {
        [XmlAttribute]
        public string NiceName { get; set; }
        [XmlText]
        public string Name { get; set; }
    }
