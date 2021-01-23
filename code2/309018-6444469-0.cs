    public class Building 
    {
        public int id { get; set; }
        public Site Site { get; set; }
        ...
    }
    public class SiteConfiguration : EntityTypeConfiguration<Site> 
    {
        public SiteConfiguration() 
        {
            HasMany(c => c.buildings);
        }
    }
    public BuildingConfiguration : EntityTypeConfiguration<Building> 
    {
        public BuildingConfiguration()
        {
            HasRequired(s=>s.Site);
        }
    }
