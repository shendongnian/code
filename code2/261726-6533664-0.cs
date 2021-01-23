    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ISessionFactory sessionFactory = BuildSessionFactory();
    
        public static ISession CurrentSession
        {
            get{ return HttpContext.Current.Items["NHibernateSession"] as ISession;}
            set { HttpContext.Current.Items["NHibernateSession"] = value; }
        }
    
        public MvcApplication()
        {
            BeginRequest += (sender, args) =>
            {
                CurrentSession = sessionFactory.OpenSession();
            };
            EndRequest += (o, eventArgs) =>
            {
                var session = CurrentSession;
                if (session != null)
                {
                    session.Dispose();
                }
            };
        }
    
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
    
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    
        private static ISessionFactory BuildSessionFactory()
        {
            return new Configuration()
                .Configure()
                .BuildSessionFactory();
        }
    }
    public class HomeController : SessionController
    {
        public ActionResult Blog(int id)
        {
            var blog = MvcApplication.CurrentSession.Get<Blog>(id);
    
            return Json(blog, JsonRequestBehavior.AllowGet);
        }
    }
