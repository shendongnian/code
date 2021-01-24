csharp
[ApplyRegExpToAllDoubleTypes]
public class MyModel {
    public double Balance { get; set; }
    public double InstallmentsDue { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class ApplyRegExpToAllDoubleTypes : ValidationAttribute {
    protected override ValidationResult IsValid(object currentObject, ValidationContext validationContext) {
        if (currentObject == null) {
            return new ValidationResult("Object can't be null");
        }
        var properties = validationContext.ObjectType.GetProperties().Where(x => x.PropertyType == typeof(double));
        foreach (var property in properties) {
            //Here I compare the double property value against '5'
            //Replace the following with the custom regex check
            if ((double)property.GetValue(currentObject) < 5) {
                return new ValidationResult("All double properties must be greater than 5");
            }
        }
        return ValidationResult.Success;
    }
}
