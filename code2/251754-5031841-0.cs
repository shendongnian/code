    //By using the NinjectHttpApplication, it automatically takes care of controllers, starting up ninject, etc.
    //Ninject.Web.Mvc
    public class MvcApplication : NinjectHttpApplication
    {
        //Your other stuff here. No need to call StartNinject().
        #region Inversion of Control
        protected override IKernel CreateKernel()
        {
            return Container;
        }
        static IKernel _container;
        public static IKernel Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new StandardKernel(new SiteModule());
                }
                return _container;
            }
        }
        internal class SiteModule : NinjectModule
        {
            public override void Load()
            {
                //Set up ninject bindings here.
                Bind<IMilestoneService>().To<MileStoneService>();
            }
        }
        #endregion
    }
