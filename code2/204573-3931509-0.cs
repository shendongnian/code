    [Serializable]
    [XmlRootAttribute("Server", Namespace = "", IsNullable = false)]    
    public class YourClass
    {
        public YourClass()
        {
    
        }
        [XmlAttribute]
        public string Manufacturer { get; set; }
       ....
    
    }
