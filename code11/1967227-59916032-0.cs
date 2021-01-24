csharp
[Fact]
public void Test1() {
    var entity = new DomainEntity("Valid");
    var nameChecker = new EntityNameChecker();
    Assert.True(nameChecker.IsDomainEntityNameValid(entity));
}
Now, maybe we want to add a new required property to the domain entity:
csharp
public sealed class DomainEntity {
    public string Name { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public DomainEntity(string name, DateTimeOffset date) {
        Name = name;
        Date = date;
    }   
}
The new constructor argument breaks the test (and probably lots of other tests).
So we introduce a builder:
csharp
public sealed class DomainEntityBuilder {
    public string Name { get; set; } = "Default Name";
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    public DomainEntity Build() => new DomainEntity(Name, Date);
}
And modify our test slightly:
csharp
[Fact]
public void Test1()
{
    // Instead of calling EntityBuilder's constructor, use DomainEntityBuilder
    var entity = new DomainEntityBuilder{ Name = "Valid" }.Build();
    var nameChecker = new EntityNameChecker();
    Assert.True(nameChecker.IsDomainEntityNameValid(entity));
}
Now, the test is no longer tightly coupled to the entity's constructor. The builder provides sane defaults for all properties, and each test provides only the values that are relevant to that specific test. Methods (or extension methods) can be added to the builder to help set up more complex scenarios.
There are libraries that can help solve this sort of problem. I've used [Bogus](https://github.com/bchavez/Bogus) in a few different projects. I think [AutoFixture](https://github.com/AutoFixture/AutoFixture) is a popular option, but I haven't used it myself. I recommend starting with a simple home-brew implementation, and adding a 3rd-party library only if the home-brew implementation becomes too tedious or complicated to maintain.
