            static void Main(string[] args)
            {
                CompositionRoot.Wire(new DependencyModule());
    
                IDrawPresenter prisenter = new DrawPresenter();//kernel.Get<IDrawPresenter>();
                prisenter.Show();
                Console.ReadLine();
            }
    
        public class CompositionRoot
        {
            private static IKernel _ninjectKernel;
    
            public static void Wire(INinjectModule module)
            {
                _ninjectKernel = new StandardKernel(module);
            }
    
            public static T Resolve<T>()
            {
                return _ninjectKernel.Get<T>();
            }
        }
    
        public class DependencyModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IDrawView>().To<DrawWindow>();
            }
        }
    
        public abstract class BasePresenter<TView> : IPrisenter<TView>
        where TView : IView
        {
            protected BasePresenter()
            {
                View = CompositionRoot.Resolve<TView>();//NinjectProgram.Kernel.Get<TView>();
            }
            protected TView View { get; private set; }
    }
