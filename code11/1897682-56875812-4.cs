    public abstract class Property
    {
        public string Name { get; set; }
        public abstract void DoSomething();
    }
    public abstract class Property<T> : Property
    {
        public T Value { get; set; }
    }
    public class StringProperty : Property<string>
    {
        public override void DoSomething() =>
            Console.WriteLine($"String of length {Value?.Length}");
    }
    public class IntListProperty : Property<List<int>>
    {
        public override void DoSomething() =>
            Console.WriteLine($"Int list has {Value?.Count} items");
    }
