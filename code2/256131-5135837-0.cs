    public class Project
    {
        [XmlElement("ProjectItem", typeof(ProjectItem))]
        public ProjectItemCollection { get; set; }
    }
