    class FooBarAction : IAction
    {
        public Foo Receiver { get; private set; }
        public FooBarAction(Foo foo)
        {
            this.Receiver = foo;
        }
        public void Invoke()
        {
            this.Receiver.Bar();
        }
    }
    ...
    IAction myAction = new FooBarAction(foo);
