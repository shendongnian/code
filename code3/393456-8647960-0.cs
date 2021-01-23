    public interface ITestService<T>
    {
    }
    public class TestService<T> : ITestService<T>
    {
    }
    public interface ITest<T>
    {
      ITestService<T> TestService { get; }
    }
    public class Test<T> : ITest<T>
    {
      readonly ITestService<T> _TestService;
      public Test(ITestService<T> testService)
      {
        _TestService = testService;
      }
      public ITestService<T>
      {
        get
        {
          return this._TestService;
        }
      }
    }
    builder.RegisterGeneric(typeof(TestService<>)).As(typeof(ITestService<>)).InstancePerLifetimeScope();
    builder.RegisterGeneric(typeof(Test<>)).As(typeof(ITest<>)).InstancePerLifetimeScope();
    ...
    _componentContext.Resolve<ITest<TNodeToNodeConnectorRecord>>();
    // if you need to specify the ITestService type to use:
    var testService = _componentContext.Resolve<TestService<TNodeToNodeConnectorRecord>>();
    var test = _componentContext.Resolve<Func<ITestService<TNodeToNodeConnectorRecord>, ITest<TNodeToNodeConnectorRecord>>>()(testService);
