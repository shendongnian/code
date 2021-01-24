    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public NpgsqlTsVector SearchVector { get; set; }
        public int? ParentId { get; set; }
        public Location Parent { get; set; }
    }
