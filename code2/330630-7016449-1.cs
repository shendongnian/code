    // DI Bindings, Ninject style
    Bind<Func<MyContext>>().ToMethod(
        c => new MyContext(
                 c.Kernel.Get<IConnectionManager>().IsOnline()
                     ? OnlineConnectionString 
                     : OfflineConnectionString));
    // Usage
    public class ThingRepository : IThingRepository 
    {
        private Func<MyContext> _getContext;
        public ThingRepository(Func<MyContext> getContext)
        {
            _getContext = getContext;
        }
        public IEnumerable<Thing> GetAllThings()
        {
            using(var context = _getContext())
            {
                return context.Things.ToList();
            }
        }
    }
