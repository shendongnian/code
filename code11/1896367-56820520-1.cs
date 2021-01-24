    public abstract class Place
    {
        public string Name { get; protected set; }
        public abstract void WriteLine();
    }
    public class Toilet : Place
    {
        public Toilet (string name) => Name = name;
        public override void WriteLine() => Console.WriteLine($"This is toilet {Name}");
    }
    // do the corresponding thing with Restaurant
