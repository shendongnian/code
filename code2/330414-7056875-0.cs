    public class VarianceHandler<TSubCommand, TBaseCommand> 
        : ICommandHandler<TSubCommand>
        where TSubCommand : TBaseCommand
    {
        private readonly ICommandHandler<TBaseCommand> handler;
        public VarianceHandler(ICommandHandler<TBaseCommand> handler)
        {
            this.handler = handler;
        }
        public void Handle(TSubCommand command)
        {
            this.handler.Handle(command);
        }
    }
