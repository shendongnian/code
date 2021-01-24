    public class Style : FullAuditedEntity
    {   
        [InverseProperty("Style")] 
        public List<StyleXStyle> Alikes { get; set; } = new List<StyleXStyle>();
        [InverseProperty("Opposite")]
        public List<StyleXStyle> Opposites { get; set; } = new List<StyleXStyle>();
    }
    public class StyleXStyle : FullAuditedEntity
    {
        [ForeignKey("Opposite")]
        public virtual int OppositeId { get; set; }
        public Style Opposite { get; set; }
     
        [ForeignKey("Style")]
        public virtual int StyleId { get; set; }
        public Style Style { get; set; }
    }
