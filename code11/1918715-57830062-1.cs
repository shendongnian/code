csharp
void Main()
{
    var emp = new Employee { FName = "John Smith", Married = true };
    var val = new EmployeeValidator();
    val.ValidateAndThrow(emp);
}
public class Employee
{
    public string FName { get; set; }
    public bool Married { get; set; }
    public string WifeName { get; set; }
    public string Wife_dOB { get; set; }
}
public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(e => e.WifeName).NotEmpty().When(e => e.Married);
        RuleFor(e => e.Wife_dOB).NotEmpty().When(e => e.Married);
    }
}
----------
**EDIT**
*I forgot to include an example of the output from the validation code above.*
Example output:
>ValidationException: Validation failed: 
> -- WifeName: 'Wife Name' must not be empty.
> -- Wife_dOB: 'Wife_d OB' must not be empty.
----------
An alternative approach, and in my opinion a better one, would be something like this that requires no validation, at least for the Married property:
 csharp
public class Person
{
    public Person(string firstName, string surname, DateTime dateOfBirth)
    {
        FirstName = firstName;
        Surname = surname;
        DateOfBirth = dateOfBirth;
    }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string FullName => $"{FirstName} {Surname}";
    public DateTime DateOfBirth { get; }
}
public class Employee : Person
{
    public Employee(string firstName, string lastName, DateTime dateOfBirth, DateTime dateOfHire)
        : base(firstName, lastName, dateOfBirth)
        => DateOfHire = dateOfHire;
    public DateTime DateOfHire { get; }
    public Person Spouse { get; set; }
    public bool IsMarried => Spouse != null;
}
With this implementation the ```IsMarried``` property simply projects whether or not the ```Spouse``` property is set.  This is purely for convenience but can often be helpful.
----------
Some validation that might make sense for these objects could be the following:
 csharp
public class PersonValidator : AbstractValidator<IPerson>
{
    public PersonValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty();
        RuleFor(p => p.Surname).NotEmpty();
        RuleFor(p => p.DateOfBirth).SetValidator(new DateOfBirthValidator());
    }
}
public class EmployeeValidator : AbstractValidator<IEmployee>
{
    private static readonly DateTime CompanyInceptionDate
        = DateTime.Today.Subtract(TimeSpan.FromDays(365.25d * 10d));
    public EmployeeValidator()
    {
        // Person rules
        RuleFor(p => p.FirstName).NotEmpty();
        RuleFor(p => p.Surname).NotEmpty();
        RuleFor(p => p.DateOfBirth).SetValidator(new DateOfBirthValidator());
        // Employee rules
        RuleFor(e => e.DateOfHire).SetValidator(
            // Can't be in the future nor older than the company
            new DateRangeValidator(CompanyInceptionDate, DateTime.Today));
    }
}
// This class really isn't necessary
// The built-in InclusiveBetween/ExclusiveBetween validators would work just as well
public class DateRangeValidator : PropertyValidator
{
    protected const double DaysInAYear = 365.25d;
    public DateRangeValidator(DateTime from, DateTime to)
        : base($"{{PropertyName}} out of range. Expected between {from:yyyy-MM-dd} and {to:yyyy-MM-dd}.")
    {
        From = from;
        To = to;
    }
    public DateTime From { get; }
    public DateTime To { get; }
    protected override bool IsValid(PropertyValidatorContext context)
        => context.PropertyValue is DateTime date
            ? date >= From && date <= To
            : false;
}
public class DateOfBirthValidator : DateRangeValidator
{
    private static readonly TimeSpan OneHundredAndFiftyYears
        = TimeSpan.FromDays(DaysInAYear * 150d);
    public DateOfBirthValidator()
        // Can't be in the future nor older than 150 years
        : base(DateTime.Today.Subtract(OneHundredAndFiftyYears), DateTime.Today) { }
}
