<PinComponent Completed="@PinCompleted"></PinComponent>
<PinComponent Completed="@ConfirmationPinCompleted" ValidationMessage="@validationMessage"></PinComponent>
@code {
    private string _pin;
    private string _confirmationPin;
    private bool _valid = false;
    private string ValidationMessage => _valid ? string.Empty : "PIN does not match";
    private void PinCompleted(string pin)
    {
        _pin = pin;
    }
    private void ConfirmationPinCompleted(string pin)
    {
        _confirmationPin = pin;
        if (_pin.Equals(_confirmationPin))
        {
            _valid = true;
        }
    }
}
if you want to utilize Blazor Forms validation
class PinModel
{
    [Required]
    public string Pin {get;set;}
    [Required]
    [PinTheSame]
    public string PinConfirmation {get;set;}
}
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class PinTheSameAttirbute: ValidationAttribute
{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
        if (value == null) return new ValidationResult("A pin is required.");
        // Make sure you change PinModel to whatever  the actual name is
        if ((validationContext.ObjectType.Name != "PinModel") 
             return new ValidationResult("This attribute is being used incorrectly.");
        if (((PinModel)validationContext.ObjectInstance).ConfirmPin != value.ToString())
            return new ValidationResult("Pins must match.");
        return ValidationResult.Success;
        }
}
and pass Values as model
<EditForm Model="@Model">
    <PinComponent Value="@Pin"></PinComponent>
    <PinComponent Value="@ConfirmationPin"></PinComponent>
</EditForm>
Last approach not fully complete, but should give you idea about the direction.
