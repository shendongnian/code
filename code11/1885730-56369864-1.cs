public interface IReportedIssueFactory
{
    // I used the enum here, but you could use the int instead.
    IReportedIssueManager CreateIssueManager(IssueType issueType);
}
In your dependency registration, add the `TypedFactoryFacility` to your container:
    container.AddFacility<TypedFactoryFacility>();
Then register all of the implementations of `IReportedIssueManager`, giving them names (which will be important later.) Since the point is that they all implement `IReportedIssueManager`, for the purpose of this factory it doesn't matter if those classes implement other interfaces. Register them according to their concrete types.
For this example I'm using the names of types to name the dependencies just because it avoids adding a "magic string" constant. The actual names can be whatever you choose, but they're not important except that you use them elsewhere.
    container.Register(
        Component.For<IReportedIssueManager, CreateReportedXIssueManager>()
            .Named(typeof(CreateReportedXIssueManager).FullName),
        Component.For<IReportedIssueManager, CreateReportedYIssueManager>()
            .Named(typeof(CreateReportedYIssueManager).FullName),
        Component.For<IReportedIssueManager, CreateReportedZIssueManager>()
            .Named(typeof(CreateReportedZIssueManager).FullName)
    );
Next, create a class which will take an input (in this case the `issueTypeId`) and return the *name* of the correct dependency:
    public class IssueManagerSelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            var issueType = (IssueType)arguments[0];
            switch (issueType)
            {
                case IssueType.Listing:
                    {
                        return typeof(CreateReportedXIssueManager).FullName;
                    }
                case IssueType.Post:
                    {
                        return typeof(CreateReportedYIssueManager).FullName;
                    }
                case IssueType.User:
                    {
                        return typeof(CreateReportedZIssueManager).FullName;
                    }
                default:
                    // So I didn't have to create an exception type as I tested.
                    throw new Exception("Unknown type");
            }
        }
    }
Finally, register the following with your container:
    container.Register(Component.For<IReportedIssueFactory>()
        .AsFactory(new IssueManagerSelector()));
You don't need to actually create an implementation of `IReportedIssueFactory`. You can just inject the interface and Windsor supplies the implementation.
It will do the following:
- When you call `CreateIssueManager` it will pass your `IssueType` argument to the `GetComponentName` method of `IssueManagerSelector`. 
- That method will select a component name and return it.
- The factory will then resolve the component with that name and return it.
The factory works by convention. Windsor assumes that a factory interface method that returns something is the "create" method. That's why we didn't need to give it a particular name.
Here's a unit test to ensure that it works as expected:
    [TestMethod]
    public void WindsorFactoryTest()
    {
        var container = new WindsorContainer();
        container.AddFacility<TypedFactoryFacility>();
        container.Register(
            Component.For<IReportedIssueManager, CreateReportedXIssueManager>()
                .Named(typeof(CreateReportedXIssueManager).FullName),
            Component.For<IReportedIssueManager, CreateReportedYIssueManager>()
                .Named(typeof(CreateReportedYIssueManager).FullName),
            Component.For<IReportedIssueManager, CreateReportedZIssueManager>()
                .Named(typeof(CreateReportedZIssueManager).FullName)
        );
        container.Register(Component.For<IReportedIssueFactory>()
            .AsFactory(new IssueManagerSelector()));
        var factory = container.Resolve<IReportedIssueFactory>();
        Assert.IsInstanceOfType(factory.CreateIssueManager(IssueType.Listing), typeof(CreateReportedXIssueManager));
        Assert.IsInstanceOfType(factory.CreateIssueManager(IssueType.Post), typeof(CreateReportedYIssueManager));
        Assert.IsInstanceOfType(factory.CreateIssueManager(IssueType.User), typeof(CreateReportedZIssueManager));
    }
Finally, here is [Windsor's documentation](https://github.com/castleproject/Windsor/blob/master/docs/typed-factory-facility.md).
