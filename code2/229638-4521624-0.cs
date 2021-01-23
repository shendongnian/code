    public interface IInteract
    {
       Type A { get; set; }
       Type B { get; set; }
    }
    public class Interact : IInteract
    {
        public Type A
        {
            get { return a; }
        }
        public Type B
        {
            get { return b; }
        }
    }
