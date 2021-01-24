    public interface IBird
        {
            Egg Lay();
        }
        public class Egg
        {
            private readonly Func<IBird> _createBird;
            private bool _hatched;
    
            public Egg(Func<IBird> createBird)
            {
                _createBird = createBird;
            }
    
            public IBird Hatch()
            {
                if (_hatched)
                    Console.WriteLine("Egg are already hatched");
                _hatched = true;
                Console.WriteLine("Egg are hatched now;");
                Console.ReadKey();
                return _createBird();
            }
        }
    
        public class Chicken : IBird
        {
            public Egg Lay()
            {
                var egg = new Egg(() => new Chicken());
                return egg;
            }
        }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                var chicken1 = new Chicken();
                var egg = chicken1.Lay();
                var childChicken = egg.Hatch();
            }
        }
