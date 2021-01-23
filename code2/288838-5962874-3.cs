    public class SomeService
    {
        private readonly IHandler<MyCommand> handler;
        public SomeService(IHandler<MyCommand> handler)
        {
            this.handler = handler;
        }
        public void ExecuteSomeCommand()
        {
            this.handler.Handle(new MyCommand
            {
                SomeInt = someInt,
                SomeEnum = someEnum
            });
        }
    }
