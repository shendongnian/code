    public class MyClass : ICloneable
    {
        public int Id { get; set; }
        public object Clone() => MemberwiseClone();
    }
