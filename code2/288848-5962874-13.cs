    public FakeSomeService : SomeService
    {
        public int SomeInt;
        public SomeEnum SomeEnum;
        protected override Command CreateCommand(int someInt, 
            SomeEnum someEnum)
        {
            this.SomeInt = someInt;
            this.SomeEnum = someEnum;
            return new FakeCommand();
        }
        private sealed class FakeCommand : Command
        {
            public override void Execute() { }
        }
    }
