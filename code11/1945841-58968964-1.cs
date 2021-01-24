    [Required]
    public int BizObjectId { get; set; }
    [ForeignKey(name: "BizObjectId")]
    public virtual BizObject BizObject { get; set; }
 
