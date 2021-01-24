    public class SpecDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        public int ProductId { get; set; }
                
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
