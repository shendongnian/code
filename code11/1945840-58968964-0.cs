    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [ForeignKey(name: "BizObjectId")]
    [Required]
    public int BizObjectId { get; set; }
    public virtual BizObject BizObject { get; set; } 
