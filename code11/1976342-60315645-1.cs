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
        public static List<(Type Master, Type Writer)> RegisteredWriters = new List<(Type Master, Type Writer)>
            {
               (typeof(IA),  typeof(WriterA)),
               (typeof(IB),  typeof(WriterB))
            };
        public static IWriterStrategy GetStrategy(IMaster thing)
        {
            (Type Master, Type Writer) writerTypeItem = RegisteredWriters.Find(x => x.Master.IsAssignableFrom(thing.GetType()));
            if (writerTypeItem.Master != null)
            {
                return (IWriterStrategy)Activator.CreateInstance(writerTypeItem.Writer, thing);
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
    public interface IC : IMaster
    {
        string PropOnC { get; set; }
    }
    public class ThingB : IB
    {
        public string PropOnB { get => "IB"; set => throw new NotImplementedException(); }
    }
    public class ThingA : IA
    {
        public string PropOnA { get => "IA"; set => throw new NotImplementedException(); }
    }
    public class ThingC : IC
    {
        public string PropOnC { get => "IC"; set => throw new NotImplementedException(); }
    }
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var things = new List<IMaster> { 
                new ThingA(),
                new ThingB()//,
                //new ThingC()
            };
            
            foreach (var thing in things)
            { 
                var strategy = WriterFactory.GetStrategy(thing);  //this gets the strategy object from our `registry` if one exists
                strategy.Execute();
            }
        }
    }
