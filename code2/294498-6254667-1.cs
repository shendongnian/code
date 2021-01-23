    public class ProjectImageMap : EntityTypeConfiguration<ProjectImage>
    {
        public ProjectImageMap()
        {
            ToTable("ProjectImages");
            HasKey(pi => pi.Id);
            HasRequired(pi => pi.Project);
            HasRequired(pi => pi.Image);
        }
    }
