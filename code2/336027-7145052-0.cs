    class RootClass
    {
        public event EventHandler<ResolveEventArgs> Resolve;
        public RootClass() { }
        public RootClass(EventHandler<ResolveEventArgs> resolve)
        {
            if (resolve != null)
                Resolve += resolve;
        }
    }
    class InheritedClass : RootClass
    {
        public InheritedClass() { }
        public InheritedClass(EventHandler<ResolveEventArgs> resolve)
            : base(resolve) // Is this what you are looking for?
        {
        }
    }
