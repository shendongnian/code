    IUnityContainer myContainer = new UnityContainer();
    myContainer.Configure<InjectedMembers>()
               .ConfigureInjectionFor<MyObject>(
                   new InjectionProperty("MyProperty"),
                   new InjectionProperty("MyStringProperty", "SomeText"))
    );
