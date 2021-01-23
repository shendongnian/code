    [Required]
    [Range(1,10,ErrorMessage="Not in the 1-10 Range"]
    public int Rating { get; set; }
    
    [Required]
    [StringLength(1024,ErrorMessage="Incorrect format")]
    public string Body { get; set; }
