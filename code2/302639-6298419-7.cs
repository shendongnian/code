    public class MyNinjectModules : NinjectModule
        {
            public override void Load()
            {
                Bind<ITemplate>().To< TemplateImplementation>();
                Bind<Generator>().ToSelf();
        }
    }
