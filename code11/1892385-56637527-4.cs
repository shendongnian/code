    public interface IPostalCodeValidator
    {
        ValidationResult ValidatePostalCode(Address address);
    }
    public class AddressValidator
    {
        private readonly IPostalCodeValidator _postalCodeValidator;
        public AddressValidator(IPostalCodeValidator postalCodeValidator)
        {
            _postalCodeValidator = postalCodeValidator;
        }
        public ValidationResult ValidateAddress(Address address)
        {
            var result = new ValidationResult();
            if (string.IsNullOrEmpty(address.Line1))
                result.AddError("Address line 1 is empty.");
            if (string.IsNullOrEmpty(address.City))
                result.AddError("The city is empty.");
            var postalCodeValidation = _postalCodeValidator.ValidatePostalCode(address);
            if (postalCodeValidation.HasErrors)
                result.AddErrors(postalCodeValidation.Errors);
            return result;
        }
    }
