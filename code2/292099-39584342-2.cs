    public class Location
    {
        public int Id { get; set; }
        ...
        public Location ParentLocation { get; set; }
        [ForeignKey("ParentLocation")]
        public int ParentLocationId { get; set; }
    }
