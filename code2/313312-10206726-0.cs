    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Description")]
    public string Desc { get; set; }
