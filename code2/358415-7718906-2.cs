    public class Mapping
    {
        [Key, ForeignKey("Field"), Column(Order=0)]
        public int StoreID { get; set; }
        [Key, ForeignKey("Field"), Column(Order=1)]
        public int ID { get; set; }
        [Key, ForeignKey("Template"), Column(Order=2)]
        public int TemplateID { get; set; }
        public Field Field { get; set; }
        public Template Template { get; set; }
    }
