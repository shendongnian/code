	// Plugin interface assembly defines
	interface ICarInfoProvider
	{
		IEnumerable<string> CarTypes { get; }
	}
	// Plugin Bmw Assembly defines
	public class BmwPluginCarInfoProvider : ICarInfoProvider
	{
		IEnumerable<string> CarTypes { 
			get { return new List<string> { "Sedan", "3", "5" }; } 
		}
	}
	public class BmwPluginModule : NinjectModule
	{
		public override Load() {
			// Or use ctor to define car name
			this.Bind<ICarInfoProvider>().To<BmwPluginCarInfoProvider>();
			this.Bind<ICar>().To<BmwCar>().Named("Sedan").OnActivation(car => car.Name = "Sedan");
			this.Bind<ICar>().To<BmwCar>().Named("3").OnActivation(car => car.Name = "3");
			this.Bind<ICar>().To<BmwCar>().Named("5").OnActivation(car => car.Name = "5");
		}
	}
	// Plugin Toyota Assembly defines
	public class ToyotaPluginCarInfoProvider : ICarInfoProvider
	{
		IEnumerable<string> CarTypes { 
			get { return new List<string> { "Yaris", "Prius", }; } 
		}
	}
	public class ToyotaPluginModule : NinjectModule
	{
		public override Load() {
			// Or use ctor to define car name
			this.Bind<ICarInfoProvider>().To<ToyotaPluginCarInfoProvider>();
			this.Bind<ICar>().To<ToyotaCar>().Named("Yaris").OnActivation(car => car.Name = "Yaris");
			this.Bind<ICar>().To<ToyotaCar>().Named("Prius").OnActivation(car => car.Name = "Prius");
		}
	}
	// Application
	var kernel = new StandardKernel(new NinjectSettings { 
		// Ensure here that assembly scanning is activated
	 });
	 
	 public class NinjectSetup : NinjectModule
	{
		public override void Load()
		{
				Bind<CarLogFactory>().ToSelf().InSingletonScope();
				
				// Sorry for being vague here but I'm in a hurry
				Bind<ICarLogger>().ToMethod(x => x.ContextPreservingGet<CarLogFactory>(new ConstructorArgument("vehicleName", ctx => // access here named parameter or use own parameter to get name //).CreateLogger());
		}
	}
	// Somewhere in your code
	var infos = resolutionRoot.GetAll<ICarInfoProvider>();
	// User chooses "Sedan"
	var sedan = resolutionRoot.Get<ICar>("Sedan");
