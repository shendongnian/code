    class ItemBase { }
    class Item : ItemBase { }
    class City : Item { }
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<City> cities = new List<City>();
            IEnumerable<Item> items = cities;  // Compile error here. IEnumerable<Item> is not a supertype of IEnumerable<City>.
        }
    }
