    public class MvcApplication : NinjectHttpApplication {
      ...
      ...
    
      protected override IKernel CreateKernel() {
        var kernel = new StandardKernel();
        kernel.Load(Assembly.GetExecutingAssembly());
        // Register services with Ninject DI Container    
        kernel.Bind<IFileSystemService>().To<FileSystemService>();
        return kernel;
      }
    
      ...
    }
