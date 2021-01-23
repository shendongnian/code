    public class RestServiceModel : NinjectModule
        {
            public override void Load()
            {
                Bind<ITXESIIDService>().To<TXESIIDService>();
                ...
            }
        }
