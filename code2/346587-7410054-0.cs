    public class Holder
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        [XmlElement("Thing")]
        public Thing[] Thingies { get; set; }
    }
