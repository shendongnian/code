    public class DataAccessBootstrapper : INinjectModuleBootstrapper
    {
        public IList<INinjectModule> GetModules()
        {
            //this is where you will be considering priority of your modules.
            return new List<INinjectModule>()
                       {
                           new DataObjectModule(),
                           new RepositoryModule(),
                           new DbConnectionModule()
                       };
            //RepositoryModule cannot be loaded until DataObjectModule is loaded
            //as it is depended on DataObjectModule and DbConnectionModule has
            //dependency on RepositoryModule
        }
    }
