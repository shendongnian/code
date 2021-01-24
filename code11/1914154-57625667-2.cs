    public class DependencyModule : NinjectModule {
        public override void Load() {
            Bind<IDrawView>().To<DrawWindow>();
            Bind<IDrawPresenter>().To<DrawPresenter>();
        }
    }
