lang-csharp
public class MyUnitTest
{
	[Fact]
	public void Test()
	{
		var query = CreateMockQuery(
			new Person { Name = "Bob" },
			new { Id = default(int), Name = default(string) } // Declares the anonymous type
		);
		var result = query.Get(5, p => new { Id = 5, p.Name });
		Assert.Equal("Bob", result.Name);
	}
	private IQuery<T> CreateMockQuery<T, TSelect>(
		T source,
		TSelect _ /* captures the anonymous type*/)
	{
		var mockQuery = new Mock<IQuery<T>>();
		mockQuery
			.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<Expression<Func<T, TSelect>>>()))
			.Returns(
				(int id, Expression<Func<T, TSelect>> select)
					=> select.Compile()(source));
		return mockQuery.Object;
	}
}
public class Person
{
	public string Name { get; set; }
}
public interface IQuery<T>
{
	TSelect Get<TSelect>(int id, Expression<Func<T, TSelect>> select);
}
