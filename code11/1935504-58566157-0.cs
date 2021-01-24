    public class ReadBlockDefinition
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public int Length { get; set; }
        public int Offset { get; set; }
    }
