    interface ICanMilk
    {
        int GetAmountOfMilk();
    }
    class Cow : ICanMilk
    {
        public string Name { get; set; }
        public int GetAmountOfMilk()
        {
            return 1000;
        }
    }
    class Sheep : ICanMilk
    {
        public string Name { get; set; }
        public int GetAmountOfMilk()
        {
            return 500;
        }
    }
    class Goat : ICanMilk
    {
        public string Name { get; set; }
        public int GetAmountOfMilk()
        {
            return 100;
        }
    }
    class Program
    {
        public static void Main(string [] args)
        {
            List<ICanMilk> list = new List<ICanMilk>();
            list.Add(new Cow());
            list.Add(new Goat());
            list.Add(new Sheep());
        }
    }
