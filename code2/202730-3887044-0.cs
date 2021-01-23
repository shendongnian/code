    public interface IApple
    {
        Flavor Flavor { get; }
    }
    public interface IToffeeApple : IApple
    {
        ICollection<Sweet> Sweets { get; }
    }
    public class MyToffeeApple : IToffeeApple
    {
        public Flavor Flavor { get { return Flavors.ToffeeFlavor; } }
        public ICollection<Sweet> Sweets { get { return new Sweet[0]; } }
    }
