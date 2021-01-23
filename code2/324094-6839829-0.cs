    public interface IMyServiceResolver
    {
        List<IMyServiceInterface> Resolve(Type[] types);
    }
    public class NinjectMyServiceResolver : IMyServiceResolver
    {
        private IKernal container = null;
        public NinjectMyServiceResolver(IKernal container)
        {
            this.container = container;
        }
        public List<IMyServiceInterface> Resolve(Type[] types)
        {
            List<IMyServiceInterface> services = new List<IMyServiceInterface>();
        
            foreach(var type in types)
            {
                IMyServiceInterface instance = container.Get(type);
                services.Add(instance);
            }
            return services;
        }
    }
    public abstract class MyController : Controller
    {
        private IMyServiceResolver resolver = null;
        public MyController(IMyServiceResolver resolver) 
        { 
            this.resolver = resolver;
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
