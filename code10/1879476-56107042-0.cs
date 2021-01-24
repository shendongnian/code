public class GenericClass<T> where T : class 
{
   protected static ISession Session => SessionManager.Instance.GetSession();
   public T GetById(object id)
   {
      return Session.Get(id, LockMode.None);        
   }
}
public sealed class NHibernateSessionManager: IExtension<OperationContext> 
{
        /// <summary> session of current thread and current domain
		/// </summary>
		private INhibernateSession _threadSession;
		public static NHibernateSessionManagerInstance {
			get {
				if (OperationContext.Current != null) {
					var sesManager = OperationContext.Current.Extensions.Find<NHibernateSessionManager>();
					if (sesManager == null) {
						sesManager = new NHibernateSessionManager();
						OperationContext.Current.Extensions.Add(sesManager);
					}
					return sesManager;
				}
				return _instance ?? (_instance = new NHibernateSessionManager());
			}
		}
		[ThreadStatic]
		private static NHibernateSessionManager _instance;
        /// <summary>Gets a session with or without an interceptor.
		/// This method is not called directly; instead,
		/// it gets invoked from other public methods.
		/// </summary>
        private INhibernateSession GetSession(IInterceptor interceptor) {
            INhibernateSession session = _threadSession;
			
			if (session == null) {
				session = NhibernateSessionFactory.OpenSession(interceptor);
				_threadSession = SetConnectionIsolationLevel(session, IsolationLevel.ReadUncommitted);
			}
			else {
                if(/* your condition or just Connect */) {
					Connect();
				}
				else {
					CloseSession();
					return GetSession(interceptor);
				}
			}
			return session;
		}
class NhibernateSession : INhibernateSession 
{
        private readonly ISession _session;
        public NhibernateSession(ISession session) 
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }
        public ISession Session => _session;
        
        public T Get<T>(object id, LockMode lockMode) {
            return _session.Get<T>(id, lockMode);
        }
}
public interface INhibernateSession
{
        /// <summary>
        /// Strongly-typed version of <see cref="M:NHibernate.ISession.Get(System.Type,System.Object,NHibernate.LockMode)" />
        /// </summary>
        T Get<T>(object id, LockMode lockMode);
}
class NhibernateSessionFactory 
{
        private static Dictionary<string, ISessionFactory> _sessionFactories;
        internal static INhibernateSession OpenSession(IInterceptor interceptor) 
        {
            return interceptor != null
                      ? new NhibernateSession(SessionFactory.OpenSession(interceptor))
                      : new NhibernateSession(SessionFactory.OpenSession());            
        }
        private static ISessionFactory SessionFactory {
            get {
                ISessionFactory sessionFactory;
                lock (typeof(NhibernateSessionFactory)) {
                    if (_sessionFactories == null) {
                        _sessionFactories = new Dictionary<string, ISessionFactory>();
                    }
                }
                
                //here you should add your condition and then check it
                //if u dont need it just remove the check
                lock (_sessionFactories) {
                    if (!_sessionFactories.ContainsKey(/* your key */)) 
                    {
                        _sessionFactories.Add(/* your key */, CreateSessionFactory());
                    }
                    sessionFactory = _sessionFactories[/* your key */];
                }
                return sessionFactory;
            }
        }
        private static ISessionFactory CreateSessionFactory() {
            var configuration = new Configuration();
            //here we add all hbm.xml mapping into configuration
            NHibernateHelpers.AddMapping(configuration);
            return configuration.BuildSessionFactory();
        }
//the trick is here, here we load all mappings
internal class NHibernateHelpers
    {        
        public static void AddMapping(Configuration cfg)
        {
            // you can use some params to replace it in the mapping file
            // for example if you need same tables with different data in it
            // Employee01, Enoloyee02 and in mapping file you could write something like  Employee<code>
            var @params = new Dictionary<string, object>
            {
               { "code", "01" },                
            };
            var assemblies = new Queue<Assembly>(AppDomain.CurrentDomain.GetAssemblies());
            var assemblyNames = assemblies.Select(ass => ass.FullName).ToList();
            
            while (assemblies.Count > 0)
            {
                Assembly ass = assemblies.Dequeue();
                //for each assebmly look for
                //ReferencedAssemblies and load them
                foreach (var refAss in ass.GetReferencedAssemblies())
                {
                    if (!assemblyNames.Contains(refAss.FullName))
                    {
                        // condition to load only your assemblies here we check for 
                        //unsigned one
                        if (refAss.GetPublicKeyToken().Length == 0)
                        {
                            assemblies.Enqueue(Assembly.Load(refAss.FullName));
                            assemblyNames.Add(refAss.FullName);
                        }
                    }
                }
            }
            List<Assembly> assembles = AppDomain.CurrentDomain.GetAssemblies().ToList();
           
            foreach (var assembly in assembles)
            {
                // if assembly is dynamic there is an Exception
                try
                {
                    var tmp = assembly.Location;
                }
                catch
                {
                    continue;
                }
                
                foreach (var resName in assembly.GetManifestResourceNames())
                {
                    if (resName.EndsWith(".hbm.xml"))
                    {
                        var str = new StreamReader(assembly.GetManifestResourceStream(resName)).ReadToEnd();
                        //here u can replace parameters you need I've left comment above
                        //str = str.Replace(...)
                        cfg.AddXmlString(str);
                    }
                }
            }
        }
    }
}
Hope it will help.
