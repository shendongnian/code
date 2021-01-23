    void OnApplicationStart()
    {
        StaticKernelContainer.Kernel = new StandardKernel(new YourInjectionModule());
    }
    void AfterMEFHasDoneWhatItNeedsToDo()
    {
        // (You may need to use Rebind at this point)
        StaticKernelContainer.Kernel.Bind<ICarLogger>().To(importer.CarType);
    }
