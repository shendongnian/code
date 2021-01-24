cs
public class ClassWithSomeUserInterfaceMethod
{
    private readonly IDataContextsFactory dataContextsFactory;
    public ClassWithSomeUserInterfaceMethod(IDataContextsFactory dataContextsFactory)
    {
        this.dataContextsFactory = dataContextsFactory;
    }
    public void SomeUserInterfaceMethod() 
    {
        using (var context = dataContextsFactory.GetDataContext()) 
        {
            var service = new MyService(context);
            service.PerformSomeAction();
        }
    }
}
You can pass any class that implements `IDataContextsFactory` interface in `dataContextsFactory`.
Easy testing example:
cs
public AnotherDatabaseDataContextFactory : IDataContextsFactory
{
    public IDataContext GetDataContext()
    {
        return new AnotherDataContext();
    }
}
[Test]
public void SomeTest()
{
    var factory = new AnotherDatabaseDataContextFactory();
    var classWithSomeUserInterfaceMethod = new ClassWithSomeUserInterfaceMethod(factory);
    classWithSomeUserInterfaceMethod.SomeUserInterfaceMethod();
    // Assert.That ...
}
Hope it helps.
