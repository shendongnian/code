     class PartMetadata
     {
         [Required]
         [DisplayName("Part number")]
         [Required(ErrorMessage="* Required")]
         [StringLength(50, MinimumLength = 3, ErrorMessage = "* Part numbers must be between 3 and 50 character in length.")]
         public string Number { get; set; }
