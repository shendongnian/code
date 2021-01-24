    public class Cars
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string DriversId { get; set; }
        [ForeignKey("DriversId")]
        public Drivers Drivers { get; set; }
    }
    public class Drivers
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
    }
