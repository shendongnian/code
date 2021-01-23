        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            // Register your new model binder
            ModelBinders.Binders.DefaultBinder = new EnumModelBinder();
        }
