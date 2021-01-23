    public class Cage<T> where T : Animal
    {
        public T Contents { get; set; }
    }
    public class Aquarium : Cage<Fish> { }
    public abstract class Animal
    {
        public abstract Cage<Animal> GetCage();
    }
    public class Fish : Animal
    {
        public override Cage<Animal> GetCage()
        {
            return (Cage<Animal>)(new Aquarium());
        }
    }
