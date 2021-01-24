    class Program
    {
        static void Main(string[] args)
        {
            List<ISellable> boughtItems = new List<ISellable>
            {
                new BottleOfWater(),
                new Sugar(),
                new Chocolate(),
                new Sugar(),
                new BottleOfWater(),
                new BottleOfWater(),
                new BottleOfWater(),
                new BottleOfWater(),
                new BottleOfWater()
            };
            Console.WriteLine("| Name | Price |");
            foreach (ISellable boughtItem in boughtItems.OrderBy(x => x.Price).OrderBy(x => x.Name))
            {
                Console.WriteLine(string.Format("| {0} | {1} |", boughtItem.Name, boughtItem.Price));
            }
        }
    }
    public interface ISellable
    {
        string Name { get; set; }
        double Price { get; set; }
    }
    public class BottleOfWater : ISellable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public BottleOfWater()
        {
            Name = "Bottle Of Water";
            Price = 2.55;
        }
    }
    public class Sugar : ISellable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Sugar()
        {
            Name = "Sugar";
            Price = 1.3;
        }
    }
    public class Chocolate : ISellable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Chocolate()
        {
            Name = "Chocolate";
            Price = 50;
        }
    }
