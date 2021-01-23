    class IoCModule : NinjectModule
	{
		public override Load()
		{
			Bind<IRepository>().To<MyEf4Repository>();
			Bind<IRepositoryDependency1>().To<...>();
			Bind<IRepositoryDependency2>().To<...>();
		}
	}
	
