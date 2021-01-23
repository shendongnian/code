    public class Mapping
    {
        [Key, Column(Order=0)]
        public int StoreID { get; set; }
        [Key, Column(Order=1)]
        public int ID { get; set; }
        [Key, Column(Order=2)]
        public int TemplateID { get; set; }
        [ForeignKey("StoreID, ID")]
        public Field Field { get; set; }
        [ForeignKey("TemplateID")]
        public Template Template { get; set; }
    }
