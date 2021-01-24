public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
If you wish to validate the age of the `Person` instance, you can write the rule as follows:
RuleFor(x => x.Age)
              .GreaterThan(0)      // in-built validator method
              .WithMessage("Age must be greater than 0");
Suppose you wish to add some custom check for age, then you can write your own method for this. Something like this:
bool BeAverageHumanAge(int age)
{
    if(age >= 0 && age <= 100)
        return true;
    return false;
}
This method can be used for the validation of age something like this:
RuleFor(x => x.Age)
              .Must(BeAverageHumanAge)      // invoking custom validation method
              .WithMessage("Age does not lie in average human age range");
