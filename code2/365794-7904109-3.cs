    public static class BootstrapHelper
    {
        public static StandardKernel LoadNinjectKernel(IEnumerable<Assembly> assemblies)
        {
            var standardKernel = new StandardKernel();
            foreach (var assembly in assemblies)
            {
                assembly
                    .GetTypes()
                    .Where(t =>
                           t.GetInterfaces()
                               .Any(i =>
                                    i.Name == typeof(INinjectModuleBootstrapper).Name))
                    .ToList()
                    .ForEach(t =>
                                 {
                                     var ninjectModuleBootstrapper =
                                         (INinjectModuleBootstrapper)Activator.CreateInstance(t);
                                     standardKernel.Load(ninjectModuleBootstrapper.GetModules());
                                 });
            }
            return standardKernel;
        }
    }
