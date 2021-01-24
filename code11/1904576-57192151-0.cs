    public class FooMethodsBaseClass
    {
        protected FooSettings Settings { get; }
        public FooMethodsBaseClass(FooSettings settings)
        {
            Settings = settings;
        }
        public virtual void WriteTag()
        {
        }
    }
