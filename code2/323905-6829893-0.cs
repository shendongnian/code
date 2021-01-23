    public static ValidationResult ValidationMethod(MyClass person, ValidationContext context)
    {
        if (person!= null)
        {
            if (string.IsNullOrWhiteSpace(person.Email) &&
                string.IsNullOrWhiteSpace(person.Address)
            {
                return new ValidationResult(....);
            }
        }
        return ValidationResult.Success;
    }
