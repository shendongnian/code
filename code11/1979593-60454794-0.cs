C#
class MyClass
{
    public MyClass(int id, int nextId, string name)
    {
        Id = id;
        NextId = nextId;
        Name = name;
    }
    public int Id { get; set; }
    public int NextId { get; set; }
    public string Name { get; set; }
}
Fluent Assertions does not know about consecutiveness, instead we can create two lists such that each matching pair across the lists corresponds to consecutive items in the original list. 
We can now compare the two lists to see if each pair across the lists has the desired relationship.
To compare the two lists by `NextId` and `Id` we need to instruct Fluent Assertions how to compare two instances of `MyClass`.
For `BeEquivalentTo` you can specify how to compare to instances of a given type using the `Using<T>()` + `WhenTypeIs<T>()` combination.
Note that per default will try to match the two lists in any order, but by specifying `WithStrictOrdering()` it will be pairwise comparison.
c#
[TestMethod]
public void Lists_BeEquivalentTo()
{
    var objects = new[]
    {
        new MyClass(1, 2, "Foo"),
        new MyClass(2, 3, "Bar"),
        new MyClass(3, 4, "Baz")
    };
    objects.Take(objects.Length - 1).Should().BeEquivalentTo(objects.Skip(1), opt => opt
        .WithStrictOrdering()
        .Using<MyClass>(e => e.Subject.NextId.Should().Be(e.Expectation.Id))
        .WhenTypeIs<MyClass>());
}
If the comparison is as simple as comparing two ints, one could also use the `Equal()` assertion which just takes two lists and a predicate that specifies when two elements are equal.
c#
[TestMethod]
public void Lists_Equal()
{
    var objects = new[]
    {
        new MyClass(1, 2, "Foo"),
        new MyClass(2, 3, "Bar"),
        new MyClass(3, 4, "Baz")
    };
    objects.Take(objects.Length - 1).Should().Equal(objects.Skip(1),
        (a, b) => a.NextId == b.Id);
}
