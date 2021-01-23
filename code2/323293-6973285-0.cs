    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(x =>
            {
                x.For<IConsumer>().Use<Consumer>();
                x.For<IHelper>().Use<Helper>();
            });
    
            var consumer = container.GetInstance<IConsumer>();
            consumer.Consume();
        }
    }
    
    public class Consumer : IConsumer
    {
        private readonly Func<IHelper> _helper;
    
        public Consumer(Func<IHelper> helper)
        {
            _helper = helper;
            Console.WriteLine("Created Consumer");
        }
    
        public void Consume()
        {
            Console.WriteLine("Consuming");
            _helper().Help();
        }
    }
    
    public interface IConsumer
    {
        void Consume();
    }
    
    public interface IHelper
    {
        void Help();
    }
    
    public class Helper : IHelper
    {
        public Helper()
        {
            Console.WriteLine("Created Helper");
        }
    
        public void Help()
        {
            Console.WriteLine("Helping");
        }
    }
