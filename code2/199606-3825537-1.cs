    public class TestLog
    {
        private Func<string, ILog> logFactory;
        public TestLog(Func<string, ILog> logFactory)
        {
             this.logFactory = logFactory;
        }
        public ILog CreateLog(string name)
        {
            return logFactory(name);
        }
    }
    Container.RegisterType<Func<string, ILog>>(
         new InjectionFactory(c => 
            new Func<string, ILog>(name => new Log(name))
         ));
    TestLog test = Container.Resolve<TestLog>();
    ILog log = test.CreateLog("Test Name");
