	[PSerializable]
	public class LoggingAspect : OnMethodBoundaryAspect, IInstanceScopedAspect
	{
		[IntroduceMember(Visibility = Visibility.Public, OverrideAction = MemberOverrideAction.Ignore)]
		[CopyCustomAttributes(typeof(ImportMemberAttribute))]
		public IInjectedObject InjectedObject { get; set; }
		[ImportMember("InjectedObject", IsRequired = true)]
		public Property<IInjectedObject> InjectedObjectProperty;
		public override void OnEntry(MethodExecutionArgs args)
		{
			var data = InjectedObjectProperty.Get().MyData;
			Debug.Print($"OnEntry: {args.Method.Name}, Data: {data}\n");
		}
		public object CreateInstance(AdviceArgs adviceArgs)
		{
			return MemberwiseClone();
		}
		public void RuntimeInitializeInstance()
		{
		}
	}
then register the service that we want to use the aspect on in our `Startup` method:
public IServiceProvider ConfigureServices(IServiceCollection services)
{
	services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
	var builder = new ContainerBuilder();
	builder.Populate(services);
	builder.RegisterType<TestService>().As<ITestService>()
		.InstancePerLifetimeScope()
		.OnActivated(e => e.Context.InjectUnsetProperties(e.Instance))
		;
	builder.RegisterType<InjectedObject>().As<IInjectedObject>()
		.InstancePerLifetimeScope()
		;
	var container = builder.Build();
	return new AutofacServiceProvider(container);
}
and add the aspect to the method we want to log:
public class TestService : ITestService
{
	public TestService()
	{
		Debug.Print("TestService ctor\n");
	}
	private int _myData = 100;
	[LoggingAspect]
	public int GetData()
	{
		return _myData++;
	}
}
When the service is created during a request, a new one is created scoped to that request, and it gets a new `IInjectedObject` stuck into it which is also scoped to the request, even though the IInjectedObject property doesn't appear in our source code.
