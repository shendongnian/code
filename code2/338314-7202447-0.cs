        protected void Application_Start()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // As you can see, it checks if the assembly has plugin in it's name
                // If you want something more solid, replace it at will
                if (assembly.ManifestModule.Name.ToLower().Contains("plugin"))
                {
                    BoC.Web.Mvc.PrecompiledViews.ApplicationPartRegistry.Register(assembly);
                }
            }
          
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
