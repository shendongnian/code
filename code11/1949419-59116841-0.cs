    using System.ComponentModel.DataAnnotations.Schema;
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        [ForeignKey("brand")]
        public int BrandId { get; set; }
        public Brand brand { get; set; }
    }
