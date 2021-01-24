    [XmlRoot("MainDTOList")]
    public class SomeClass
    {
        [XmlElement("SubDTO")]
        public SubDTO SubDTO{get;set;}
    
        [XmlElement("SubDTO")]
        public LockDTO LockDTO{get;set;}
    
        ....
        
    }
