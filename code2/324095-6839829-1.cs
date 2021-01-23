    public abstract class MyController : Controller
    {
        private static IMyServiceResolver resolver = null;
        public static InitializeResolver(IMyServiceResolver resolver)
        {
            MyController.resolver = resolver;
        }
        public MyController() 
        { 
            // Now we support a default constructor
            // since maybe someone else is instantiating this type
            // that we don't control.
        }
        protected void DoActions(Type[] types)
        {
            var services = resolver.Resolve(types);
            foreach(var service in services)
            {
                service.DoAction();
            }
        }
    }
