    public abstract class Place
    {
        public Place(string name) => Name = name;
        public string Name { get; }
        public abstract void WriteLine();
    }
    public class Toilet : Place
    {
        public Toilet (string name) : base(name) {}
        public override void WriteLine() => Console.WriteLine($"This is toilet {Name}");
    }
    // do the corresponding thing with Restaurant
