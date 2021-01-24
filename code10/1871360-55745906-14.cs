    public class Product {
        [Required]
        [FromRoute] //<--
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }    
    }
