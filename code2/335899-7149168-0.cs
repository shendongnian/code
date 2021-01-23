public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
{
    if (YourField.Length == 2)
    {
        yield return new ValidationResult("ut oh!!");
    }
}
