    public class ChangeNameCommandHandler : IHandle<ChangeNameCommand>
    {
        ISession session;
       
        public ChangeNameCommandHandler(ISession session)
        {
            // You could demand an IPersonRepository instead of using the session directly.
            this.session = session;
        }
       
        public void Handle(ChangeNameCommand command)
        {
            var person = session.Load<Person>(command.PersonId);
            person.ChangeName(command.NewName);
        }
    }
