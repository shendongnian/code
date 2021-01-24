public class EmailSender
{
	public void SendOrderEmail(string orderCode)
	{
		Order order = GetOrderService().SearchByCode(orderCode);
		//....Send email with the order ....
	}
	private IOrderService GetOrderService()
	{
		return AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IOrderService>();
	}
}
...and you're looking to specifically run unit tests over `SendOrderEmail` to validate the logic surrounding your `IOrderService` implementation (which could be easily covered by a separate test), the other classes implied there might look like:
public class AutofacDependencyResolver	// this is problematic but we can't change it
{
	public AutofacDependencyResolver(IContainer applicationContainer)
	{
		ApplicationContainer = applicationContainer;
	}
	public IContainer ApplicationContainer { get; }
	public static AutofacDependencyResolver Current { get; private set; } 
	public static void SetContainer(IContainer container)
	{
		Current = new AutofacDependencyResolver(container);
	}
}
public static class ContainerProvider	// this sets up production config across your app
{
	public static IContainer GetProductionContainer()
	{
		var builder = new ContainerBuilder();
		builder.RegisterType<RealOrderService>()
			.As<IOrderService>();
		// register all other real dependencies here
		return builder.Build();
	}
}
	
With that setup, you only need to provide mocks which are required for the specific method you're testing, assuming you can set your container within `AutofacDependencyResolver` easily in order to have production and test configuration running in parallel. That might look like the following, using xUnit, Moq and Autofac in a test project:
public class EmailSenderTests
{
	private readonly Mock<IOrderService> _orderService;
	public EmailSenderTests()
	{
		// to set up the test fixture we'll create a mock OrderService and store a reference to the mock itself for validation later on
		_orderService = new Mock<IOrderService>();
		var mockOrder = new Order();
		_orderService.Setup(os => os.SearchByCode(It.IsAny<string>()))
			.Returns(mockOrder);
	}
	private IContainer GetTestContainer()
	{
		// here we're adding just one registration we need, setting the mocked OrderService instance to be used for IOrderService
		var builder = new ContainerBuilder();
		builder.Register(c => _orderService.Object)
			.As<IOrderService>();
		return builder.Build();
	}
	[Fact]
	public void SendEmail()
	{
		AutofacDependencyResolver.SetContainer(GetTestContainer());	// set the test container on the global singleton
		var sender = new EmailSender();
		sender.SendOrderEmail("abc");	// internally the email sender will retrieve the mock IOrderService via service location
		// make any assertions here, e.g.
		_orderService.Verify(os=>os.SearchByCode("abc"), Times.Exactly(1));
	}
}
