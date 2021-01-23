     class PartMetadata
     {
         // required keyword forces user to enter input
         [Required] 
         [DisplayName("Part number")]
         // or [Required(ErrorMessage="* Required")]
         // ErrorMessage in string only enforces when data is entered
         [StringLength(50, MinimumLength = 3, ErrorMessage = "* Part numbers must be between 3 and 50 character in length.")]
         public string Number { get; set; }
