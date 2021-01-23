    public class Job
    {
        public string Process { get; set; }
        
        [XmlElement("RelatedToProcess")]
        public List<string> RelatedProcesses { get; set; }
    }
