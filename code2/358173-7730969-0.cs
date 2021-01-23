    class Top
    {
        public Top( Foo foo, IUnityContainer container )
        {
            some = CreateSome(localRuntimeVariable);
            Child = container.Resolve<Child>(new ParameterOverride("some" some),
                new ParameterOverride("Foo", foo));
        }
        public Child Child {get;private set;}
    }
    
    class Child
    {
        public Child(ISome some, Foo foo)
        {
        }
    }
