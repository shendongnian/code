    public class AddVersionViewModel
    {
        public double Number { get; set; }
        public bool IsActive { get; set; }
    
        public int? TemplateVersionId { get; set; }
        public ICollection<Version> CurrentVersions { get; set; }
    }
