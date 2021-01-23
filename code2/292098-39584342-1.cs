    public class Location
    {
        public int Id { get; set; }
        ...
        public Location ParentLocation { get; set; }
        [ForeignKey("Location")]
        public int? ParentLocationId { get; set; }
    }
