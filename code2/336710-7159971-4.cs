    builder.RegisterType<AutofacMyType().As<MyType>();
    // Define inside Composition Root
    private sealed class AutofacMyType : MyType
    {
        public AutofacMyType(IMyService s, ISomeDependency d)
            : this(s.DoSomething(), d) { }
        private AutofacMyType(Something p1, ISomeDependency d)
            : base(p1, d.DoSomething(p1, true)) { }
    }
