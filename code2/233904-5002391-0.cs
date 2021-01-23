    [Table(Name = "Locations")]
    public class Location
    {
    
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        internal int LocationId { get; set; }
    
        [Column]        
        public int? SiteId { get; set; }
    
        [Association(ThisKey = "SiteId", OtherKey = "SiteId", IsForeignKey = true)]        
        public Site Site
        {
            get;
            set;
        }
    
    }
