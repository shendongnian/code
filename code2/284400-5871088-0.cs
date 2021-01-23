    public class HybridWebSessionContext : CurrentSessionContext
    {
        private const string _itemsKey = "HybridWebSessionContext";
        [ThreadStatic] private static ISession _threadSession;
        public HybridWebSessionContext(ISessionFactoryImplementor factory)
        {
        }
        protected override ISession Session
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    var session = HttpContext.Current.Items[_itemsKey] as ISession;
                    if (session != null)
                    {
                        return session;
                    }
                }
                return _threadSession;
            }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items[_itemsKey] = value;
                }
                else
                {
                    _threadSession = value;
                }
            }
        }
    }
