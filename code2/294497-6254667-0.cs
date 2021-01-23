    public class ProjectImage : Entity
    {
        public Guid ProjectId { get; set; }
        public Guid ImageId { get; set; }
        public virtual int DisplayIndex { get; set; }       
        public virtual Project Project { get; set; }
        public virtual Image Image { get; set; }
    }
