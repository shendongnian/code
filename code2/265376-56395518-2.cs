    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(18,99)]
        public string Age { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
    }
