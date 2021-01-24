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
            Console.WriteLine("| Name | Price | Amount |");
            List<IGrouping<Type, ISellable>> groupedBoughtItems = boughtItems.GroupBy(x => x.GetType()).ToList();
            foreach(IGrouping<Type, ISellable> group in groupedBoughtItems)
            {
                Console.WriteLine(string.Format("| {0} | {1} | {2} |", group.First().Name, group.First().Price, group.Count()));
            }
            
            Console.WriteLine(string.Format("| Total | {0} |", boughtItems.Sum(x => x.Price)));
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
