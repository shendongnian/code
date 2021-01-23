    public class NinjectRepositoryModule: NinjectModule
    {
            public override void Load()
            {
                Bind<IContactsRepository>().To<EFContactRepository>();
            }
    }
