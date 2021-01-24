    public class DependencyModule : NinjectModule {
        public override void Load() {
            Bind<IDrawView>().To<DrawWindow>();
            Binf<IDrawPresenter>().To<DrawPresenter>();
        }
    }
