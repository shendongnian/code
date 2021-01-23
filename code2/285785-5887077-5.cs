    public interface IAnimal { void Move(); }    
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
