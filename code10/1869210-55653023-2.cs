    public class MoveCustomerCommandHandler : CommandHandlerBase<MoveCustomerCommandHandler, MoveCustomerCommand>
        {
            public override void Handle(MoveCustomerCommand command) => Console.WriteLine("Moving the customer");
        }
    
        public class KillCustomerCommandHandler : CommandHandlerBase<KillCustomerCommandHandler, KillCustomerCommand>
        {
            public override void Handle(KillCustomerCommand command) => Console.WriteLine("Killing the customer");
        }
