    public class ProjectSponsor 
    {     
        // This is how you instantiate me!
        public ProjectSponsor(Project project, Sponsor sponsor)
        {
            this.Project = project;
            this.Sponsor = sponsor;
        }
    
        protected ProjectSponsor()
        {
            // I exist for NHibernates benefit only!
        }
    
        public virtual Project Project { get; set; }     
    
        public virtual Sponsor Sponsor { get; set; } 
    }
