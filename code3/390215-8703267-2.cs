    public class UserContext
    {
        private UserContext()
        {
        }
        public static UserContext Current
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    return null;
                if (HttpContext.Current.Session["UserContext"] == null)
                    BuildUserContext();
                
                return (UserContext)HttpContext.Current.Session["UserContext"];
            }
        }
        private static void BuildUserContext()
        {
            BuildUserContext(HttpContext.Current.User);
        }
        private static void BuildUserContext(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return;
            // For my application, I use DI to get a service to retrieve my domain
            // user by the IPrincipal
            var personService = DependencyResolver.Current.GetService<IUserBaseService>();
            var person = personService.FindBy(user);
            if (person == null) return;
            var uc = new UserContext { IsAuthenticated = true };
            // Here is where you would populate the user data (in my case a SiteUser object)
            var siteUser = new SiteUser();
            // This is a call to ValueInjecter, but you could map the properties however
            // you wanted. You might even be able to put your object in there if it's a POCO
            siteUser.InjectFrom<FlatLoopValueInjection>(person);
            // Next, stick the user data into the context
            uc.SiteUser = siteUser;
            // Finally, save it into your session
            HttpContext.Current.Session["UserContext"] = uc;
        }
        #region Class members
        public bool IsAuthenticated { get; internal set; }
        public SiteUser SiteUser { get; internal set; }
        // I have this method to allow me to pull my domain object from the context.
        // I can't store the domain object itself because I'm using NHibernate and
        // its proxy setup breaks this sort of thing
        public UserBase GetDomainUser()
        {
            var svc = DependencyResolver.Current.GetService<IUserBaseService>();
            return svc.FindBy(ActiveSiteUser.Id);
        }
        // I have these for some user-switching operations I support
        public void Refresh()
        {
            BuildUserContext();
        }
        public void Flush()
        {
            HttpContext.Current.Session["UserContext"] = null;
        }
        #endregion
    }
