    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFoo>().To<MyFoo>().Intercept().With<CustomInterceptor>();
        }
    }
