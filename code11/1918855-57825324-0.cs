    public interface IProduct
    {
        string Name { get;}
        double Price { get;}
        void Store(IProduct product);
    }
    public class Apple : IProduct
    {
        public Apple(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; }
        public double Price { get; }
        public void Store(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
    public class Toy : IProduct
    {
        public Toy(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; }
        public double Price { get; }
        public void Store(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
    public class Playground
    {
        void Test()
        {
            IProduct apple = new Apple("apple", 11);
            ICollection<IProduct> apples = new List<IProduct>() { new Apple("apple", 230)};
            apple.Store(apple);
            IProduct toy = new Toy("toy", 11);
            ICollection<IProduct> toys = new List<IProduct>() { new Toy("toy", 230)};
        }
    }
