    public class AddressValidator
    {
        public ValidationResult ValidateAddress(Address address)
        {
            var result = new ValidationResult();
            if(string.IsNullOrEmpty(address.Line1))
                result.AddError("Address line 1 is empty.");
            if(string.IsNullOrEmpty(address.City))
                result.AddError("The city is empty.");
            // more validations
            
            return result;
        }
    }
