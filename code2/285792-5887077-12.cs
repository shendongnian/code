    public class Program
    {
        static void DoMove<T>(T animal) where T : IAnimal
        {
            animal.Move();
        }
        public static void Main(string[] args)
        {            
            Duck duck = new Duck(); 
            Fish fish = new Fish();
            Ant ant = new Ant(); 
 
            DoMove<Duck>(duck);
            DoMove<Fish>(fish);
            DoMove<Ant>(ant);
        }
    }
