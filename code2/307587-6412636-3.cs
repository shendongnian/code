    public static class MyClassFactory
    {
        public static MyClass CreateNew(IService service)
        {
            return new MyClass(service);
        }
    }
    container.Register<MyClass>(new InjectionFactory(c => 
    {   
        return MyClassFactory.Create(c.Resolve<IService>());
    })); 
