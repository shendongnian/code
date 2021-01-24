    class Program
    {
        static void Main(string[] args)
        {
            List<Coin> coins = new List<Coin>()
            {
                new Coin ("BTC", 1),
                new Coin ("ETH", 2),
                new Coin ("LTC", 3),
                new Coin ("USDT", 4),
            };
            Coin usdt = coins.FirstOrDefault(x => x.Name == "USDT");
            coins.Remove(usdt);
            Coin first = coins.OrderByDescending(x => x.Value).FirstOrDefault();
            Console.WriteLine(string.Format("{0} --- Value: {1}", first.Name, first.Value));
            Console.WriteLine(string.Format("{0} --- Value: {1}", usdt.Name, usdt.Value));
        }
    }
    
    public class Coin
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public Coin(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
