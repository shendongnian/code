    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new Pizza(1);
            Pizza pizza2 = new Pizza(1);
            bool equal = AreEqual(pizza1, pizza2, new PizzaComparer());
            Console.WriteLine(equal);
        }
        public static bool AreEqual<T>(T field, T value, IEqualityComparer<T> equalityComparer)
        {
            return equalityComparer.Equals(field, value);
        }
    }
    public class Pizza
    {
        public Pizza(int slices)
        {
            Slices = slices;
        }
        public int Slices { get; set; }
    }
    public class PizzaComparer : IEqualityComparer<Pizza>
    {
        public bool Equals(Pizza pizza1, Pizza pizza2)
        {
            return pizza1.Slices == pizza2.Slices;
        }
        public int GetHashCode(Pizza pizza)
        {
            return pizza.Slices.GetHashCode();
        }
    }
