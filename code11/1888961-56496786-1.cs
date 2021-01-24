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
            Coin usdt = coins.First(x => x.Name == "USDT");
            coins.Remove(usdt);
            coins = new List<Coin>() { coins.OrderByDescending(x => x.Value).First(), usdt };
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
