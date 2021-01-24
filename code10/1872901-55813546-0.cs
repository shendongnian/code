    public interface DomainFault : 
        Fault
    {
        string Code { get; }
    }
