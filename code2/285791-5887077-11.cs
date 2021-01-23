    public interface IAnimal 
    { 
        void Move(); 
    }
    public class Duck : IAnimal
    {
        public void Move() 
        { 
            Console.WriteLine("Flying"); 
        }
    }
    public class Fish : IAnimal
    {
        public void Move()
        { 
            Console.WriteLine("Swimming"); 
        }
    }
    public class Ant : IAnimal
    {
        public void Move()
        { 
            Console.WriteLine("Walking"); 
        }
    }    
