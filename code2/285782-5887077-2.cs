    public interface IAnimal
    {
        void Move();
    }    
    public class Duck : IAnimal
    {
        public Duck() { }
        public void Move() { Console.WriteLine("Flying"); }
    }
    public class Fish : IAnimal
    {
        public Fish() { }
        public void Move() { Console.WriteLine("Swimming"); }
    }
    public class Ant : IAnimal
    {
        public Ant() { }
        public void Move() { Console.WriteLine("Walking"); }
    }    
    public class Test
    {
        protected static void DoMove<T>(T animal) where T : IAnimal
        {
            animal.Move();
        }    
        public void RunTest()
        {
            List<IAnimal> animals = new List<IAnimal>
            {
                new Duck(),
                new Fish(),
                new Ant()
            };    
            foreach (var animal in animals)
            {
                DoMove(animal);
            }
        }
    }
    
