c#
public class CustomerEmployeeComparer : IEquivalencyStep
{
    public bool CanHandle(IEquivalencyValidationContext context,
        IEquivalencyAssertionOptions config)
    {
        return context.Subject is Customer
            && context.Expectation is Employee;
    }
    public bool Handle(IEquivalencyValidationContext context, IEquivalencyValidator
        parent, IEquivalencyAssertionOptions config)
    {
        var customer = (Customer)context.Subject;
        var employee = (Employee)context.Expectation;
        customer.Name.Should().Be(employee.FirstName, context.Because, context.BecauseArgs);
        customer.Age.Should().Be(employee.Age, context.Because, context.BecauseArgs);
        return true;
    }
}
To use `CustomerEmployeeComparer` in an assertion, add it by invoking `Using(new CustomerEmployeeComparer())` on the `EquivalencyAssertionOptions config` parameter of `BeEquivalentTo`.
Note: As your example requires the two lists to be compared in order, I've added [`WithStrictOrdering()`](https://fluentassertions.com/documentation/#ordering) to the example below.
c#
[TestMethod]
public void CompareCustomersAndEmployeesWithCustomEquivalencyStep()
{
    // Arrange
    var customers = new[] {
        new Customer { Name = "John", Age = 42 },
        new Customer { Name = "Mary", Age = 43 }
    };
    var employees = new[] {
        new Employee { FirstName = "John", Age = 42 },
        new Employee { FirstName = "Mary", Age = 43 }
    };
    // Act / Assert
    customers.Should().BeEquivalentTo(employees, opt => opt
        .Using(new CustomerEmployeeComparer())
        .WithStrictOrdering());
}
public class Employee
{
    public string FirstName { get; set; }
    public int Age { get; set; }
}
public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
}
Changing the name of the first `Employee` to Jonathan, now gives this failure message:
Message: Expected item[0] to be "Jonathan" with a length of 8, but "John" has a length of 4, differs near "hn" (index 2).
With configuration:
- Use declared types and members
- Compare enums by value
- Include all non-private properties
- Include all non-private fields
- Match member by name (or throw)
- Without automatic conversion.
- UnitTestProject15.CustomerEmployeeComparer
- Without automatic conversion.
- Always be strict about the collection order
For anyone interested, there is a related open issue about overriding which properties to compare. 
https://github.com/fluentassertions/fluentassertions/issues/535
