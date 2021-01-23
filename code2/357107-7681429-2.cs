    public class PointOfInterestContext : DbContext
    {
        public IDbSet<PointOfInterest> PointOfInterest { get; set; }
        public IDbSet<POITag> POITag { get; set; }
        public IDbSet<Tag> Tag { get; set; }
    
        public override OnModelCreating(DbModelBuilder modelBuilder)
        {
            // custom mappings go here
            base.OnModelCreating(modelBuilder)
        }
    }
    
    public class PointOfInterest
    {
        // properties
        public int Id { get; set; }
        public string Title { get; set; }
        // etc...
    
        // navigation properties
        public virtual IEnumerable<POITag> POITags { get; set; }    
    }
    
    public class POITag
    {
        // properties
        public int Id { get; set;}
        public int PointOfInterestId { get; set; }
        public int TagId { get; set; }
    
        // navigation properties
        public virtual PointOfInterest PointOfInterest { get; set; }
        public virtual Tag Tag { get; set; }
    }
    
    public class Tag
    {
        // properties
        public int Id { get; set; }
        public string TagName { get; set; }
        // etc...
    
        // navigation properties
        public virtual IEnumerable<POITags> POITags { get; set; }    
    }
