    // Foreign Keys
    public Guid Plant_Id { get; set; }
    // Navigational properties
    [ForeignKey("Plant_Id")]
    public virtual Plant Plant { get; set; }
