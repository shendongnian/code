        public class FooMethodsBaseClass:IFooMethodsBaseClass
        {
            protected IFooSettings Settings { get; }
    
            public FooMethodsBaseClass(IFooSettings settings)
            {
                Settings = settings;
            }
    
            public virtual void WriteTag()
            {
    
            }
        }
