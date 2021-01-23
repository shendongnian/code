    using (IUnityContainer container = new UnityContainer())
                {
                    container.LoadConfiguration();
    
                    ITest messenger = container.Resolve<ITest>();
    
                    messenger.Hello();
                }
