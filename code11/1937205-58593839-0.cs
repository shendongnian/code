    private static IKernel RegisterDatabase(this IKernel kernel)
    {
        kernel.Bind<BaseDbContext, OtherDbContext, MainDbContext>()
            .To<MainDbContext>().InRequestScope();
        return kernel;
    }
