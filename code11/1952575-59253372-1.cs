lang-c#
public class EmployeeStatusAttribute : ValidationAttribute
{
    private string[] _allowedValues;
    public EmployeeStatusAttribute(string[] allowedValues)
    {
        _allowedValues = allowedValues;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var employee = value as Employee;
        if (_allowedValues.Contains(employee.Status))
        {
            return ValidationResult.Success;
        }
        return new ValidationResult(`{employee.Status} is not a valid status`);
    }
}
Then in your model:
lang-c#
public class Employee
{
    ...
    [EmployeeStatus("Active", "Inactive")]
    public string Status { get; set; }
    ...
}
  [1]: https://stackoverflow.com/a/17243820/12431728
  [2]: https://stackoverflow.com/a/46695926/12431728
