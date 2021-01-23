    [MetadataType(typeof(Person_Validation))]
    public partial class Person
    {
        // Partial class compiled with code produced by VS designer
    }
    [Bind(Exclude="ID")]
    public class Person_Validation
    {
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Age Required")]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [Email(ErrorMessage = "Not a valid email")]
        public string Email { get; set; }
    }
