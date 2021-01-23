    IUnityContainer container = new UnityContainer();
    container.AddNewExtension<Interception>();
    container.RegisterType<IApoClass, NonAbstractAopMethod>()
                .Configure<Interception>()
                .SetInterceptorFor<IApoClass>(new InterfaceInterceptor());
    DependencyResolver.SetResolver(new UnityServiceLocator(container));
    var nonabstractmethod = DependencyResolver.Current.GetService<IApoClass>();
    nonabstractmethod.SomeAbstractAopMethod("doubt this works");
    nonabstractmethod.SomeVirtualAopMethod("if the above didn't then why try");
