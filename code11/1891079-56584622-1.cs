    public class ColorsVM
    {
        public int Id { get; set; }
        public int produceId { get; set; }
        public string Color { get; set; }
        [ForeignKey("produceId ")]
        public Produces Produces { get; set; }
    }
