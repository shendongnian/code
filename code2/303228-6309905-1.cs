    public class MyClass : IEqualityComparer<MyClass>
    {
        // From the interface IEqualityComparer
        public bool Equals(MyClass other) { ... }
        ...
    }
