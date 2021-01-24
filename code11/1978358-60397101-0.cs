c#
public class Entity : IEnumerable<int>
{
    private int[] ints = new[] { 1 };
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerator<int> GetEnumerator() => ((IEnumerable<int>)ints).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<int>)ints).GetEnumerator();
}
[TestMethod]
public void EquivalenceTest()
{
    var expected = new Entity
    {
        Id = 1,
        Name = "abc",
    };
    var actual = new Entity
    {
        Id = 1,
        Name = "abc",
    };
    actual.Should().BeEquivalentTo(expected, opt => opt
        .Using<Entity>(e =>
            e.Subject.Should().Match<Entity>(f => f.Name == e.Expectation.Name)
            .And.Subject.Should().Match<Entity>(f => f.Id == e.Expectation.Id)
                .And.Subject.Should().BeEquivalentTo(e.Expectation)
        )
        .WhenTypeIs<Entity>());
}
