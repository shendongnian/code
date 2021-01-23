    public interface IDomainEvent { }
    public class NewMemberWasRegistered : IDomainEvent { }
    public interface IHandles<DOMAINEVENT> where DOMAINEVENT : IDomainEvent
    {
        void Handle(DOMAINEVENT args);
    }
    public class NewMemberWasRegisteredHandler : IHandles<NewMemberWasRegistered>
    {
        public void Handle(NewMemberWasRegistered args) { }
    }
    public class HandlerContainer
    {
        public List<IHandles<IDomainEvent>> Handlers { get; set; }
        public HandlerContainer()
        {
            Handlers = new List<IHandles<IDomainEvent>>();
            Handlers.Add(new NewMemberWasRegisteredHandler());
        }
    }
