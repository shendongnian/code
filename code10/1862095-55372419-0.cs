    public long? CaseID { get;set;}
    [ForeignKey("CaseID")]
    public Client_Cases Client_Case { get; set; }
    
    public long? CircleID { get; set; }
    [ForeignKey("CircleID")]
    public Court_Circles Court_Circle { get; set; }
