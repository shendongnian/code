    public class Person
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Email(ErrorMessage = "{0} appears to be invalid.")]
        public string Name { get; set; }
    }
