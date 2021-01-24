    private static void RegisterServices(IKernel kernel) {
        kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
        kernel.Bind<IAdImagePersister>().To<S3AdImagePersister>();
        //Open generic bind for repository and ad persister
        kernel.Bind(typeof(IAdRepository<>)).To(typeof(AdRepository<>));
        kernel.Bind(typeof(IAdPersister<>)).To(typeof(AdPersister<>));
    }
