    private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILog>()
                .ToMethod(c => LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType))
                .InSingletonScope();
        }
