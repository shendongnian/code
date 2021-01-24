    public partial class User
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        [MaxLength(10)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        public List<UserGroups> UserGroups { get; set; }
        public List<Referal> Referals { get; set; }
        
    }
    public partial class User : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                yield return new ValidationResult("FirstName is Required", new[] { "FirstName" });
            }
        }
    }
