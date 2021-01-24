    [MaxLength(100,ErrorMessage ="Name must be 100 characters or less.")]
    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
    [RegularExpression("^[A-Za-z0-9_. ]{3,100}$")]
    [Display(Name= "Name")]
    public virtual string? Name { get; set; }
