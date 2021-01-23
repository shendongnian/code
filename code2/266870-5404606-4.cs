    class IoCModule : NinjectModule
	{
		public override Load()
		{
			Bind<Func<Context, IRepository>>()
				.ToConstant( context => new MyEf4Repository(context, Kernel.Get<IRepositoryDependency1>, Kernel.Get<IRepositoryDependency2>) );
		}
	}
