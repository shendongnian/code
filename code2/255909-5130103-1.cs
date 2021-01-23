    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            foreach (AssemblyName name in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                Assembly asm = Assembly.Load(name);
                container.Register(AllTypes.FromAssemblyNamed(asm.FullName)
                                .Where(Component.IsInSameNamespaceAs<SqlUsersRepository>())
                                .WithService.DefaultInterface()
                                .Configure(c => c.LifeStyle.Transient
                                .DependsOn(new { databaseName = "MyDatabaseName" })));
            }
            container.Register(AllTypes.FromThisAssembly()
                                .Where(Component.IsInSameNamespaceAs<SqlUsersRepository>())
                                .WithService.DefaultInterface()
                                .Configure(c => c.LifeStyle.Transient
                                .DependsOn(new { databaseName = "MyDatabaseName" })));
        }
    }
