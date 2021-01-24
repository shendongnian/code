    private static void RegisterServices(IKernel kernel) {
        kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();        
        kernel.Bind(typeof(IAdPersisterFactory<>)).To(typeof(AdPersisterFactory<>));
        
    }
