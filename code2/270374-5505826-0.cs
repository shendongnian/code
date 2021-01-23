        [Fact]
        public void Tryout()
        {
            var kernel = new StandardKernel(new NinjectSetup());
            var car = kernel.Get<ICar>();
            Assert.Equal("Sedan", car.CarLogger.Name);
        }
    public class NinjectSetup : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICar>().To<BmwCar>();
            Bind<CarLogFactory>().ToSelf().InSingletonScope();
            Bind<ICarLogger>().ToMethod(x => x.ContextPreservingGet<CarLogFactory>(new ConstructorArgument("vehicleName", ctx => ctx.Request.ParentRequest.ParentContext.Plan.Type.GetProperty("Type", BindingFlags.Public | BindingFlags.Static).GetValue(null, null))).CreateLogger());
        }
    }
    public interface ICar
    {
        ICarLogger CarLogger { get; }
    }
    public interface ICarLogger
    {
        string Name { get; }
    }
    public class CarLogFactory
    {
    private readonly string vehicleName;
    public CarLogFactory(string vehicleName)
    {
        this.vehicleName = vehicleName;
    }
    public ICarLogger CreateLogger()
    {
        return new CarLogger(this.vehicleName);
    }
    private class CarLogger : ICarLogger
    {
        public CarLogger(string loggerName)
        {
            this.Name = loggerName;
        }
        public string Name { get; private set; }
    }
    }
    public class BmwCar : ICar
    {
        private ICarLogger _carLogger;
        public BmwCar(ICarLogger carLogger)
        {
            _carLogger = carLogger;
        }
        public static string Type
        {
            get { return "Sedan"; }
        }
        public ICarLogger CarLogger
        {
            get { return _carLogger; }
        }
        public string GetBrand()
        {
            return "BMW";
        }
    }
