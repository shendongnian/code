    public class DaisyBlossomsServices : NinjectModule
        {
            public override void Load()
            {
                Bind<IProductsRepository>().To<MySqlProductsRepository>();
                Bind<ISession>().ToProvider<BootStrapper>();
            }
        } 
