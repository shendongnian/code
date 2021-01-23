    private HomeController GenerateController(object model)
        {
            HomeController controller = new HomeController()
            {
                RoleService = new MockRoleService(),
                MembershipService = new MockMembershipService()
            };
            MvcMockHelpers.SetFakeAuthenticatedControllerContext(controller);
            // bind errors modelstate to the controller
            var modelBinder = new ModelBindingContext()
            {
                ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, model.GetType()),
                ValueProvider = new NameValueCollectionValueProvider(new NameValueCollection(), CultureInfo.InvariantCulture)
            };
            var binder = new DefaultModelBinder().BindModel(new ControllerContext(), modelBinder);
            controller.ModelState.Clear();
            controller.ModelState.Merge(modelBinder.ModelState);
            return controller;
        }
