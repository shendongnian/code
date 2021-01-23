    class A
    {
        public A(B b, C c) { }
    }
    
    class B
    {
        public B(D d) { }
    }
    
    class C
    {
        public C(D d) { }
    }
    
    ...
    container.Register(Component.For<D>().LifeStyle.Custom<ContextualLifestyle>());
    A a = container.Resolve<A>();
