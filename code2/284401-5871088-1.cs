    public class HybridWebSessionContext : CurrentSessionContext
    {
        private const string _itemsKey = "HybridWebSessionContext";
        [ThreadStatic] private static ISession _threadSession;
        // This constructor should be kept, otherwise NHibernate will fail to create an instance of this class.
        public HybridWebSessionContext(ISessionFactoryImplementor factory)
        {
        }
        protected override ISession Session
        {
            get
            {
                var currentContext = ReflectiveHttpContext.HttpContextCurrentGetter();
                if (currentContext != null)
                {
                    var items = ReflectiveHttpContext.HttpContextItemsGetter(currentContext);
                    var session = items[_itemsKey] as ISession;
                    if (session != null)
                    {
                        return session;
                    }
                }
                return _threadSession;
            }
            set
            {
                var currentContext = ReflectiveHttpContext.HttpContextCurrentGetter();
                if (currentContext != null)
                {
                    var items = ReflectiveHttpContext.HttpContextItemsGetter(currentContext);
                    items[_itemsKey] = value;
                    return;
                }
                _threadSession = value;
            }
        }
    }
