    public abstract class BaseType : IAuditEvent
    {
        public abstract MyTypeEnum TypeId { get; }
    
        ... add any base implementation of the interface ...
    }
