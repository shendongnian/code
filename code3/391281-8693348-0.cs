        IModuleWorldRepository moduleWorldRepository;
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            moduleWorldRepository = GetModuleWorldRepository();
         
        }
        IModuleWorldRepository GetModuleWorldRepository()
        {
            UserRunTimeInfo user = (UserRunTimeInfo)User.Identity;
            var context = contextProvider.GetContext(user.CurrentModuleId);
            return new ModuleWorldRepository(context);
        }
   
