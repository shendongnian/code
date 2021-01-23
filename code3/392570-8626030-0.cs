    public class Project
    {
        [ForeignKey("ProjectManagerUserId")]
        public virtual User ProjectManager { get; set; }
        public Guid ProjectManagerUserId { get; set; }
    }
