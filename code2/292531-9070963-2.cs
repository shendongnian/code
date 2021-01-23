        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            foreach (Type type in ModelEnums.Types)
            {
                ModelBinders.Binders.Add(type, new EnumModelBinder());
            }
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
