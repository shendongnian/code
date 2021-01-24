    public class DataMappingRelation
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    
        public long? DataMapping1Id { get; set; }
        public DataMapping DataMapping1 { get; set; } 
    
        public long? DataMapping2Id { get; set; }
        public DataMapping DataMapping2 { get; set; }
    }
