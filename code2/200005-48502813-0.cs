         class Program
         {
            Lazy<Dictionary<Enum, Func<IStrategy>>> dictionary = new Lazy<Dictionary<Enum, Func<IStrategy>>>(
                () =>
                    new Dictionary<Enum, Func<IStrategy>>()
                    {
                        { Enum.StrategyA,  () => { return new StrategyA(); } },
                        { Enum.StrategyB,  () => { return new StrategyB(); } }
                    }
                );
    
            IStrategy _strategy;
    
            IStrategy Client(Enum enu)
            {
                if (dictionary.Value.TryGetValue(enu, out Func<IStrategy> _func))
                {
                    _strategy = _func.Invoke();
                }
    
                return _strategy ?? default(IStrategy);
            }
    
            static void Main(string[] args)
            {
                Program p = new Program();
    
                var x = p.Client(Enum.StrategyB);
                x.Create();
            }
        }
    
        public enum Enum : int
        {
            StrategyA = 1,
            StrategyB = 2
        }
    
        public interface IStrategy
        {
            void Create();
        }
        public class StrategyA : IStrategy
        {
            public void Create()
            {
                Console.WriteLine("A");
            }
        }
        public class StrategyB : IStrategy
        {
            public void Create()
            {
                Console.WriteLine("B");
            }
        }
