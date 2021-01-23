		protected override IKernel CreateKernel()
		{
        var kernel = new StandardKernel();
			kernel.Components.Add<IActivationStrategy, MyMonitorActivationStrategy>();
			kernel.Load<AppModule>();
			return kernel;
		}
