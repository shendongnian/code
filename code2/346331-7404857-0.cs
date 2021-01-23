    [XmlRoot]
    public class MyClass
    {
        [XmlElement]
        public DateTime MyDateTime { get; set; }
        [XmlElement]
        public MySubClass TheSubClass { get; set; }
    }
    
    [XmlElement]
    public class MySubClass 
    {
        [XmlElement]
        public int ID { get; set; }
        [XmlIgnore]  // since you didn't include in XML snippet
        public string Name { get; set; }
    }
