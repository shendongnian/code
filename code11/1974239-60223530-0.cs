csharp
public abstract class IDoSomethingTestBase
{
  protected readonly IDoSomething InstanceUnderTest;
  protected IDoSomethingTestBase(IDoSomething instanceUnderTest){
    InstanceUnderTest = instanceUnderTest;
  }
  [Fact]
  public void BasicTest()
  {
    Assert.AreEqual("a_string", InstanceUnderTest.SearchString("a_string", ".*");
  }
}
Actual test class:
csharp
public class ThisDoesSomething_Tests : IDoSomethingTestBase
{
  public ThisDoesSomething_Tests(): base(new ThisDoesSomething()) { }
}
