    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new Pizza(1);
            Pizza pizza2 = new Pizza(1);
            bool equal = AreEqual(pizza1, pizza2);
            Console.WriteLine(equal);
        }
        public static bool AreEqual<T>(T field, T value)
        {
            return EqualityComparer<T>.Default.Equals(field, value);
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
