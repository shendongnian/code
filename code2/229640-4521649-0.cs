    public interface IInteract
    {
        void Interact();
    }
    public interface IInteract<TActor,TTarget> : IInteract
    {
        TActor Actor { get; set; }
        TTarget Target { get; set; }
    }
