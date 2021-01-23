    public class Product
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Your user friendly message")]
        public string Name { get; set; }
        
    }
