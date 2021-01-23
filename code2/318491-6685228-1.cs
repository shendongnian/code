    [XmlRoot("ROWSET")]
    public class PersonRowSet
    {
        [XmlElement("ROW")]
        public Person Item {get;set;}
        // ^^^ could perhaps be public List<Person> Items {get;set;}
    }
    public class Person
    {
        [XmlElement("FIRST_NAME")]
        public string first_name { get; set; }
    
        [XmlElement("MIDDLE_NAME")]
        public string middle_name { get; set; }
    
        [XmlElement("LAST_NAME")]
        public string last_name { get; set; }
    }
