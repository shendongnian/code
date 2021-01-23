    public class TemporaryRegistration {
            [Required]
            [Email(ErrorMessage = "Please enter a valid email address.")]
            [Display(Name = "Email address")]
            public string Email { get; set; }
            [Required]
            [Integer]
            [Min(1, ErrorMessage = "Please select an entity type.")]
            [Display(Name = "Entity Type")]
            public int EntityType { get; set; }
            public IEnumerable<SelectListItem> EntityTypes { get; set; }
            [Required]
            [Integer]
            [Min(1, ErrorMessage = "Please select an associated entity.")]
            [Display(Name = "Associated Entity")]
            public IEnumerable<SelectListItem> AssociatedEntity { get; set; }
    }
