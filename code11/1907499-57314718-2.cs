    [XmlRoot("project-areas", Namespace = "http://jazz.net/xmlns/prod/jazz/process/0.6/")]
    public class ProjectAreas
    {
        [XmlElement("project-area")]
        public List<ProjectArea> Areas { get; set; }
    }
    
    [XmlRoot("project-area", Namespace = "http://jazz.net/xmlns/prod/jazz/process/0.6/")]
    public class ProjectArea
    {
        [XmlAttribute("name", Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Name { get; set; }
    
        [XmlElement("summary")]
        public string Summary { get; set; }
    }
