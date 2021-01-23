    public abstract class MyBaseClass
    {
        public bool Success { get; set; }
    
        public MyBaseClass(bool success) { this.Success = success; }
    }
    public class MyConcreteClass
    {
        [Obsolete("only for serialization", true)]
        /* calling base constructor with false success parameter */
        public MyConcreteClass() : base(false) {}
    
        public MyBaseClass(bool success) : base(success) { /* whatever in this instance */ }
    }
