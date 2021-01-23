    [XmlElement("Template")]
    public class EmployerInfo
    {
        [XmlArray("Employer"), XmlArrayItem("Value")]
        public string[] _employerName;
    
        [XmlArray("Designation"), XmlArrayItem("Value")]
        public string[] _designation;
    
        [XmlArray("Duration"), XmlArrayItem("Value")]
        public string _duration;
    }
