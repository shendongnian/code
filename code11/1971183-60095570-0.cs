    var container = new Container();
    container.Register<A>(Reuse.Singleton);
    container.Register<B>(Reuse.Scoped);
    using (var tabScope1 = container.OpenScope())
    {
        var b1 = tabScope1.Resolve<B>();
    }
    using (var tabScope2 = container.OpenScope())
    {
        var b2 = tabScope2.Resolve<B>();
    }
    class A { }
    class B
    {
        private readonly A _a;
        public B(A a) { _a = a; }
    }
