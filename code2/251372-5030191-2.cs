    public static class Ioc
    {
        public static void Initialize()
        {
			var modules = new INinjectModule[] {
				new ServicesModule(),
				new DataModule()
                                new VideoProcessing.NinjectModule()
			};
			IKernel kernel = new Ninject.StandardKernel(modules);
        }
    }
