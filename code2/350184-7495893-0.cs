    public abstract class MyBaseClass
    {
        public bool Success { get; set; }
        [Obsolete("only for serialization", true)]
        public MyBaseClass(){}
    
        public MyBaseClass(bool success) { this.Success = success; }
    }
    public class MyConcreteClass
    {
        [Obsolete("only for serialization", true)]
        public MyConcreteClass() : base() {}
    
        public MyBaseClass(bool success) : base(success) { /* whatever in this instance */ }
    }
