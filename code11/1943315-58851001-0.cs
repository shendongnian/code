csharp
public class Class1 : IValidatableObject
{
    public string prop1 { get; set; }
    public int? prop2 { get; set; }
    public string prop3 { get; set; }
    public string prop24 { get; set; }
    public string prop5 { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();
        if (string.IsNullOrWhitespace(prop1) && prop2.IsNull && string.IsNullOrWhitespace(prop3) && string.IsNullOrWhitespace(prop4) && string.IsNullOrWhitespace(prop5) &&)
        {
             errors.Add(new ValidationResult($"Please provide at least one property.", new List<string> { }));
        }
        return errors;
    }
}
see Microsoft documentation https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.0#ivalidatableobject
see original answer https://stackoverflow.com/questions/58744905/asp-net-core-conditional-validation-for-controls/58745056#58745056.
