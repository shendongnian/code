    public class ChartHistory : ModelBase  
    {  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public long Id { get; set; }
        [ForeignKey("Coder")]
        public int CoderId { get; set; }  
  
        [ForeignKey("ChartStatus")]
        public int ChartStatusId { get; set; }  
        [ForeignKey("Chart")]
        public int ChartId { get; set; }  
        public virtual User Coder { get; set; }  
        public virtual ChartStatus ChartStatus { get; set; }  
        public virtual Chart Chart { get; set; }  
    }
