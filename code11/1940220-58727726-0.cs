    [Column("created_user_id")]
    public long? CreatedUserId { get; set; }
    [ForeignKey("CreatedUserId")]
    public User? CreatedUser { get; set; } = null!;     
    [Column("updated_user_id")]
    public long? UpdatedUserId { get; set; }
    [ForeignKey("UpdatedUserId")]
    public User? UpdatedUser { get; set; } = null!;
