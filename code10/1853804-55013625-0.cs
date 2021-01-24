    public class CreamModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }
    
        [ForeignKey("CreamTypeModel")] 
        public int? CreamTypeModel_id { get; set; }
        public virtual CreamTypeModel CreamTypeModel { get; set; }
    }
