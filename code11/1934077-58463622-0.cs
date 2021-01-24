    public class ProjectViewModel {    
        public string ProjectEndLabel => ProjectType == "project" ? "End date" : "Due date";
        public DateTime ProjectEnd { get; set; }
        public string ProjectType { get; set; }
        // more properties
    }
