    public class Cheese
    {
        public string Name { get; }
        public CheeseCharacteristic Characteristic { get; }
        public Cheese(string name, CheeseCharacteristic characteristic)
        {
            Name = name;
            Characteristic = characteristic;
        }
    }
    public class Program
    {
        private readonly static int[] CheeseCharacteristicValues =
            Enum.GetValues(typeof(CheeseCharacteristic)).Cast<int>().ToArray();
        public static void Main()
        {
            var pattern = CheeseCharacteristic.Yellow | CheeseCharacteristic.Mouldy;
            var cheeses = new List<Cheese>()
            {
                new Cheese("Camembert", CheeseCharacteristic.Stinks),
                
                new Cheese("MildCheddar", 
                    CheeseCharacteristic.Yellow | CheeseCharacteristic.UseOnToast),
                
                new Cheese("Stilton", 
                    CheeseCharacteristic.Yellow | CheeseCharacteristic.Stinks |
                    CheeseCharacteristic.Mouldy),
            };
            IEnumerable<Cheese> sortedCheeses = 
                cheeses.OrderByDescending(c => GetFlagCount(c.Characteristic & pattern));
            ...
        }
        private static int GetFlagCount(CheeseCharacteristic characteristic) => 
            CheeseCharacteristicValues.Count(v => ((int)characteristic & v) == v);
    }
