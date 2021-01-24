    public interface IWriterStrategy
    {
        void Execute();
    }
    public class WriterA : IWriterStrategy
    {
        private readonly IA _thing;
        public WriterA(IA thing)
        {
            _thing = thing;
        }
        public void Execute()
        {
            Console.WriteLine(_thing.PropOnA);
        }
    }
    public class WriterB : IWriterStrategy
    {
        private readonly IB _thing;
        public WriterB(IB thing)
        {
            _thing = thing;
        }
        public void Execute()
        {
            Console.WriteLine(_thing.PropOnB);
        }
    }
    public static class WriterFactory
    {
        public static IWriterStrategy GetStrategy(IMaster thing)
        {
            switch (thing)
            {
                case IA ia:
                    return new WriterA(ia);
                case IB ib:
                    return new WriterB(ib);
            }
            throw new Exception("Strategy not found!");
        }
    }
    public interface IMaster
    {
        //Some properties
    }
    public interface IA : IMaster
    {
        string PropOnA { get; set; }
    }
    public interface IB : IMaster
    {
        string PropOnB { get; set; }
    }
    public class ThingB : IB
    {
        public string PropOnB { get => "IB"; set => throw new NotImplementedException(); }
    }
    public class ThingA : IA
    {
        public string PropOnA { get => "IA"; set => throw new NotImplementedException(); }
    }
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var things = new List<IMaster> { 
                new ThingA(),
                new ThingB()
            };
            foreach (var thing in things)
            { 
                var strategy = WriterFactory.GetStrategy(thing);  //this gets the strategy object from our `registry` if one exists
                strategy.Execute();
            }
        }
    }
