    [TestClass]
    public class LogTest 
    {
        /// <summary>
        /// Test project: autofac impl.
        /// </summary>
        private readonly ContainerBuilder _builder; 
        private readonly IContainer _container;
        /// <summary>
        /// Initializes a new instance of the <see cref="LogTest" /> class.
        /// </summary>
        public LogTest()
        {
            //
            // Read autofac setup from the project we are testing
            //
            _builder = new ContainerBuilder();
            Register.RegisterTypes(_builder);
            _container = _builder.Build();
            loggingService = _container.Resolve<ILoggingService>(new NamedParameter("theType", this));
        }
        [TestMethod]
        public void DebugMsgNoExectption()
        {
            var a = _container.Resolve<IHurraService>();
            var b = a.ItsMyBirthday();
    public class HurraService : IHurraService
    {
        private IHurraClass _hurra;
        /// <summary>
        /// Initializes a new instance of the <see cref="HurraService" /> class.
        /// </summary>
        public HurraService(IHurraClass hurra)
        {
            _hurra = hurra;
        }
        /// <summary>
        /// It my birthday.
        /// </summary>
        public string ItsMyBirthday()
        {
            return _hurra.Hurra();
        }
    }
    public static class Register
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<LoggingService>().As<ILoggingService>();
            builder.RegisterType<HurraService>().As<IHurraService>();
            builder.RegisterType<HurraClass>().As<IHurraClass>();
        }
    }
 
