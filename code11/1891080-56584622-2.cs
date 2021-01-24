    public class Color
    {
        public int Id { get; set; }
        public int produceId { get; set; }
        public string Color { get; set; }
        [ForeignKey("produceId ")]
        public Produce Produce { get; set; }
    }
