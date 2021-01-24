    public string ReferenceCode { get; set; }
    public int TeamId { get; set; }
    [ForeignKey("TeamId ")]
    public Team Team { set; get; }
    public string Description { get; set; )
