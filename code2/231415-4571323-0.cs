    public class Strategy
    {
        [XmlAttribute]
        public string Name {get; set;}
    
        [XmlElement("Gate")]
        public Gate MainGate {get; get}
    }
    /// ...........
    public class Gate
    {
       
        XmlElement("Gate")
        public Gate ChildGate {get; set;}
        // ...
    }    
