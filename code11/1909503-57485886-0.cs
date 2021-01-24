public class ClassToTest
{
    private readonly IService _service;
    public ClassToTest(IService service)
    {
        _service = service;
    }
    public IList<Products> GetProducts(string categoryId)
    {
        var items = _service.Get(new Category { id = categoryId, flag = true });
        return items;
    }
}
public interface IService
{
    IList<Products> Get(Category category);
}
public class Category
{
    public string id;
    public bool flag;
    public override bool Equals(object obj)
    {
        Category c = obj as Category;
        if (c == null)
        {
            return false;
        }
        return c.id == id && c.flag == flag;
    }
}
public class Products
{
}
# Test Using Moq #
My preferred mocking framework is Moq, but I'm sure others will work just as well for this use case. Here is the test using Moq:
[Test]
public void MoqTest()
{
    // Arrange.
    var mockService = new Mock<IService>();
    var target = new ClassToTest(mockService.Object);
    // Act.
    target.GetProducts("test");
    // Assert.
    var expectedCategory = new Category {id = "test", flag = true};
    mockService.Verify(t => t.Get(expectedCategory));
}
# Test Without Mocking Framework #
You don't need to use a proper mocking framework if you don't want to. You can provide your own mock implementation:
public class MockService : IService
{
    public Category CategoryReceived { get; private set; }
    public IList<Products> Get(Category category)
    {
        CategoryReceived = category;
        return new List<Products>();
    }
}
And then test your code like this:
[Test]
public void PoorMansTest()
{
    // Arrange.
    var mockService = new MockService();
    var target = new ClassToTest(mockService);
    // Act.
    target.GetProducts("test");
    // Assert.
    var expectedCategory = new Category { id = "test", flag = true };
    Assert.That(mockService.CategoryReceived, Is.EqualTo(expectedCategory));
}
