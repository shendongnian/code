    public class Product {
        [Required]
        [FromRoute("id")] //<--
        public Guid Id { get; set; }
        [Required]
        [FromBody] //<--
        public string Name { get; set; }    
    }
