    public class MyModel : IValidatableObject
    {
    [Required(ErrorMessage = "Required!");
    public string PhoneHome{ get; set; }
    [Required(ErrorMessage = "Required!");
    public string PhoneWork{ get; set; }
    [Required(ErrorMessage = "Required!");
    public string PhoneMobile { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (PhoneHome+PhoneWork+PhoneMobile.Lenght < 1)
        {
            yield return new ValidationResult("You should set up any phone number!", new [] { "ConfirmForm" });
        }
    }
    }
