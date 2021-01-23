    public class FakeHandler<TCommand> : IHandler<TCommand>
    {
        public TCommand HandledCommand { get; set; }
        public void Handle(TCommand command)
        {
            this.HandledCommand = command;
        }
    }
