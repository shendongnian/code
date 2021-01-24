    public class Product {
        [Required]
        [FromRoute] //<--
        public Guid Id { get; set; }
        [Required]
        [FromBody] //<--
        public string Name { get; set; }    
    }
