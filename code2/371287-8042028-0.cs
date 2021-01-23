public class Person
{
    public Person(int age){ Age = age; }
    public int Age{ get; set;}
}
public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Age >= 0,
            () => new ArgumentOutOfRangeException(
                "Age must be greater than or equal to zero."
        ));
    }
}
public class Example
{
    void exampleUsage()
    {
        var john = new Person(28);
        var jane = new Person(-29);
        var personValidator = new PersonValidator();
        var johnsResult = personValidator.Validate(john);
        var janesResult = personValidator.Validate(jane);
        displayResult(johnsResult);
        displayResult(janesResult);
    }
    void displayResult(ValidationResult result)
    {
        if(!result.IsValid)
            Console.WriteLine("Is valid");
        else
            Console.WriteLine(result.Exception.GetType());
    }
}
