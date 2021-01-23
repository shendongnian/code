    _unityContainer.AddNewExtension<Interception>(); 
    
    _unityContainer.RegisterType<ITestCaching, TestCaching>(
    	new Interceptor<InterfaceInterceptor>(),
    	new InterceptionBehavior<PolicyInjectionBehavior>());
    	
    _unityContainer.RegisterType<XRepository>(
    	new Interceptor<VirtualMethodInterceptor>(),
    	new InterceptionBehavior<PolicyInjectionBehavior>());
