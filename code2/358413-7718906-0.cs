    public class Mapping
    {
        [Key, Column(Order=0)]
        [ForeignKey("Field"), Column(Order=0)]
        public int StoreID { get; set; }
        [Key, Column(Order=1)]
        [ForeignKey("Field"), Column(Order=1)]
        public int ID { get; set; }
        [Key, Column(Order=2)]
        [ForeignKey("Template")]
        public int TemplateID { get; set; }
        public Field Field { get; set; }
        public Template Template { get; set; }
    }
