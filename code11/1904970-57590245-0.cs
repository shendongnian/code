 csharp
public class ServiceTests
{
  private readonly IFixture fixture = new Fixture().Customize(new AutoMoqCustomization());
  public ServiceTests() 
  {
    fixture.Register<IService>(() => fixture.Create<Service>());
  }
  [Fact]
  public void Test()
  {
    // Arrange
    var repositoryMock = fixture.Freeze<Mock<IRepository>>();
    repositoryMock.Setup(x => x.GetInt()).Returns(1);
 
    var service = fixture.Create<IService>();
    
    // Act
    var act = service.GetStringFromInt();
    // Verify
    Assert.Equal("1", act);
  }
}
To check that you have set up autofixture correctly, you can try the following in the unit test in future.
csharp
var repo1 = fixture.Create<IRepository>();
var repo2 = fixture.Create<IRepository>();
Assert.Equal(repo1.GetHashCode(), repo2.GetHashCode());
If the above fails, that indicates that you have not frozen a type. These lines of code have saved me so much head scratching in the past...
